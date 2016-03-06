//**************************************************************************************
//API Functions
//
//alphanumeric - allow both alphabet and numeric characters
//alpha - allow only alphabet characters
//numeric - allow only numeric characters
//
//API Properties
//
//allow - add excempted characters to the rule of prevention
//ichars - define a custome set of characters to prevent
//allcaps - allow only capital letters to be entered
//nocaps - allow only lowercase characters to be entered
//onedecimal - only allows 1 decimal
//allownegative - only allow 1 dash as first char
//blockcntlkey - stops control key commands from working
//digitsafterdecimal - stops the number of digits allowed after decimal place
//
//EXAMPLES
//$('.sample5').numeric({allow:".-", onedecimal: true,allownegative:true});
//$('.sample5').numeric({ digitsafterdecimal: 5, onedecimal: true, allow: "." });
//$('.sample4').numeric();
//$('.sample6').alphanumeric({ichars:'.1a'});
//$('.sample3').alpha({nocaps:true});
//Fiddle
//http://jsfiddle.net/d1820/ttjka/embedded/result/
//**************************************************************************************
(function ($) {
    $.fn.alphanumeric = function (p) {
        baseAllowedKeyCodes = new Array(8, 9, 46, 37, 39);
        p = $.extend({
            ichars: "!@#$%^&*()+=[]\\\';,/{}|\":<>?~`.- _",
            nchars: "",
            allow: "",
            allowkeycode: "",
            blockcntlkey: true,
            onedecimal: false,
            digitsafterdecimal: null,
            allownegative: false
        }, p);
        return this.each(

        function () {
            if (p.nocaps) p.nchars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (p.allcaps) p.nchars += "abcdefghijklmnopqrstuvwxyz";
            s = p.allow.split('');
            for (i = 0; i < s.length; i++) {
                if (p.ichars.indexOf(s[i]) !== -1) {
                    s[i] = "\\" + s[i];
                }
            }

            p.allow = s.join('|');
            var reg = new RegExp(p.allow, 'gi');
            var ch = p.ichars + p.nchars;
            ch = ch.replace(reg, '');
            $(this).keydown(
            //this is to block cntl in browsers for cut and paste. if we are block certain chars anyway cntl c/v should be apart of that                    
            function (e) {
                if (window.event) {
                    e = window.event;
                }
                if (p.blockcntlkey) {
                    if (e.ctrlKey) {
                        if (typeof e.preventDefault !== 'undefined') {
                            e.preventDefault();
                        } else {
                            e.cancelBubble = true;
                        }
                        return false;
                    }
                }
            });
            $(this).keypress(

                 function (e) {
                     if (window.event) {
                         e = window.event;
                     }
                     if (e.keyCode === 0) { //FF
                         k = String.fromCharCode(e.which);
                         code = e.which;
                     } else { //IE
                         k = String.fromCharCode(e.keyCode);
                         code = e.keyCode;
                     }
                     //e.charCode is used to block numpad entries from working in FF
                     if (ch.indexOf(k) !== -1 && !isValidKeyCode(this, code, e.charCode, p.money)) {
                         if (e.preventDefault !== undefined) {
                             e.preventDefault();
                         } else {
                             e.cancelBubble = true;
                         }
                         return false;
                     }
                     //left as failsafe from the keydown event. works in FF
                     if (e.ctrlKey && k === 'v') {
                         if (e.preventDefault != undefined) {
                             e.preventDefault();
                         } else {
                             e.cancelBubble = true;
                         }
                         return false;
                     }
                     var value = $(this).val();
                     if (value.indexOf("-") !== -1 && p.allownegative && code === 45) {
                         return false;
                     }
                     if (code === 46 && value.indexOf('.') !== -1 && p.onedecimal) {
                         return false;
                     }

                     if (p.onedecimal && value.indexOf('.') > -1 && p.digitsafterdecimal !== null) {
                         var decimalIndex = value.indexOf('.');
                         var curLen = value.length;
                         if (curLen - decimalIndex > parseInt(p.digitsafterdecimal)) {
                             return false;
                         }
                     }
                     return true;
                 }
            );
            $(this).bind('contextmenu', function () {
                return false;
            });
        });

        function isValidKeyCode(obj, code, charCode, isMoney) {
            s = p.allowkeycode.split(',');
            testValues = baseAllowedKeyCodes.concat(s);
            for (var i = 0; i < testValues.length; i++) {
                if (testValues[i] === code && charCode === 0) {

                    return true;
                }
            }
            return false;
        };
    };
    $.fn.numeric = function (p) {
        var az = "abcdefghijklmnopqrstuvwxyz";
        az += az.toUpperCase();
        p = $.extend({
            nchars: az
        }, p);
        return this.each(function () {
            $(this).alphanumeric(p);
        });
    };
    $.fn.alpha = function (p) {
        var nm = "1234567890";
        p = $.extend({
            nchars: nm
        }, p);
        return this.each(function () {
            $(this).alphanumeric(p);
        });
    };
})(jQuery);
