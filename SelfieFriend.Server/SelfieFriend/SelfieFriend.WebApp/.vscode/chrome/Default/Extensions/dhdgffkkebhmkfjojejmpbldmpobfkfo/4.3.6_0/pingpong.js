Registry.require("helper",function(){var b=rea.FEATURES,a=null,d,f=function(e,c){var b=function(b){b?(null!=a&&window.clearTimeout(a),a=null,e(b)):console.log("pp: Warn: got pseudo response!")};a=window.setTimeout(function(){null!=a&&window.clearTimeout(a);a=null;0<d--?f(e,c):c&&c()},1E3);var g={method:"ping"};try{rea.extension.sendMessage(g,b)}catch(h){}};Registry.register("pingpong","5454",function(){d=b.PINGPONG.RETRIES;return{ping:f}})});
