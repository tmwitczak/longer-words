{}(function dartProgram(){function copyProperties(a,b){var u=Object.keys(a)
for(var t=0;t<u.length;t++){var s=u[t]
b[s]=a[s]}}var z=function(){var u=function(){}
u.prototype={p:{}}
var t=new u()
if(!(t.__proto__&&t.__proto__.p===u.prototype.p))return false
try{if(typeof navigator!="undefined"&&typeof navigator.userAgent=="string"&&navigator.userAgent.indexOf("Chrome/")>=0)return true
if(typeof version=="function"&&version.length==0){var s=version()
if(/^\d+\.\d+\.\d+\.\d+$/.test(s))return true}}catch(r){}return false}()
function setFunctionNamesIfNecessary(a){function t(){};if(typeof t.name=="string")return
for(var u=0;u<a.length;u++){var t=a[u]
var s=Object.keys(t)
for(var r=0;r<s.length;r++){var q=s[r]
var p=t[q]
if(typeof p=='function')p.name=q}}}function inherit(a,b){a.prototype.constructor=a
a.prototype["$i"+a.name]=a
if(b!=null){if(z){a.prototype.__proto__=b.prototype
return}var u=Object.create(b.prototype)
copyProperties(a.prototype,u)
a.prototype=u}}function inheritMany(a,b){for(var u=0;u<b.length;u++)inherit(b[u],a)}function mixin(a,b){copyProperties(b.prototype,a.prototype)
a.prototype.constructor=a}function lazy(a,b,c,d){var u=a
a[b]=u
a[c]=function(){a[c]=function(){H.de(b)}
var t
var s=d
try{if(a[b]===u){t=a[b]=s
t=a[b]=d()}else t=a[b]}finally{if(t===s)a[b]=null
a[c]=function(){return this[b]}}return t}}function makeConstList(a){a.immutable$list=Array
a.fixed$length=Array
return a}function convertToFastObject(a){function t(){}t.prototype=a
new t()
return a}function convertAllToFastObject(a){for(var u=0;u<a.length;++u)convertToFastObject(a[u])}var y=0
function tearOffGetter(a,b,c,d,e){return e?new Function("funcs","applyTrampolineIndex","reflectionInfo","name","H","c","return function tearOff_"+d+y+++"(receiver) {"+"if (c === null) c = "+"H.bt"+"("+"this, funcs, applyTrampolineIndex, reflectionInfo, false, true, name);"+"return new c(this, funcs[0], receiver, name);"+"}")(a,b,c,d,H,null):new Function("funcs","applyTrampolineIndex","reflectionInfo","name","H","c","return function tearOff_"+d+y+++"() {"+"if (c === null) c = "+"H.bt"+"("+"this, funcs, applyTrampolineIndex, reflectionInfo, false, false, name);"+"return new c(this, funcs[0], null, name);"+"}")(a,b,c,d,H,null)}function tearOff(a,b,c,d,e,f){var u=null
return d?function(){if(u===null)u=H.bt(this,a,b,c,true,false,e).prototype
return u}:tearOffGetter(a,b,c,e,f)}var x=0
function installTearOff(a,b,c,d,e,f,g,h,i,j){var u=[]
for(var t=0;t<h.length;t++){var s=h[t]
if(typeof s=='string')s=a[s]
s.$callName=g[t]
u.push(s)}var s=u[0]
s.$R=e
s.$D=f
var r=i
if(typeof r=="number")r+=x
var q=h[0]
s.$stubName=q
var p=tearOff(u,j||0,r,c,q,d)
a[b]=p
if(c)s.$tearOff=p}function installStaticTearOff(a,b,c,d,e,f,g,h){return installTearOff(a,b,true,false,c,d,e,f,g,h)}function installInstanceTearOff(a,b,c,d,e,f,g,h,i){return installTearOff(a,b,false,c,d,e,f,g,h,i)}function setOrUpdateInterceptorsByTag(a){var u=v.interceptorsByTag
if(!u){v.interceptorsByTag=a
return}copyProperties(a,u)}function setOrUpdateLeafTags(a){var u=v.leafTags
if(!u){v.leafTags=a
return}copyProperties(a,u)}function updateTypes(a){var u=v.types
var t=u.length
u.push.apply(u,a)
return t}function updateHolder(a,b){copyProperties(b,a)
return a}var hunkHelpers=function(){var u=function(a,b,c,d,e){return function(f,g,h,i){return installInstanceTearOff(f,g,a,b,c,d,[h],i,e)}},t=function(a,b,c,d){return function(e,f,g,h){return installStaticTearOff(e,f,a,b,c,[g],h,d)}}
return{inherit:inherit,inheritMany:inheritMany,mixin:mixin,installStaticTearOff:installStaticTearOff,installInstanceTearOff:installInstanceTearOff,_instance_0u:u(0,0,null,["$0"],0),_instance_1u:u(0,1,null,["$1"],0),_instance_2u:u(0,2,null,["$2"],0),_instance_0i:u(1,0,null,["$0"],0),_instance_1i:u(1,1,null,["$1"],0),_instance_2i:u(1,2,null,["$2"],0),_static_0:t(0,null,["$0"],0),_static_1:t(1,null,["$1"],0),_static_2:t(2,null,["$2"],0),makeConstList:makeConstList,lazy:lazy,updateHolder:updateHolder,convertToFastObject:convertToFastObject,setFunctionNamesIfNecessary:setFunctionNamesIfNecessary,updateTypes:updateTypes,setOrUpdateInterceptorsByTag:setOrUpdateInterceptorsByTag,setOrUpdateLeafTags:setOrUpdateLeafTags}}()
function initializeDeferredHunk(a){x=v.types.length
a(hunkHelpers,v,w,$)}function getGlobalFromName(a){for(var u=0;u<w.length;u++){if(w[u]==C)continue
if(w[u][a])return w[u][a]}}var C={},H={bk:function bk(){},aF:function aF(a,b,c){var _=this
_.a=a
_.b=b
_.c=0
_.d=null
_.$ti=c},
Z:function(a){var u,t=H.dh(a)
if(typeof t==="string")return t
u="minified:"+a
return u},
d1:function(a){return v.types[H.W(a)]},
dC:function(a,b){var u
if(b!=null){u=b.x
if(u!=null)return u}return!!J.q(a).$ibl},
c:function(a){var u
if(typeof a==="string")return a
if(typeof a==="number"){if(a!==0)return""+a}else if(!0===a)return"true"
else if(!1===a)return"false"
else if(a==null)return"null"
u=J.ai(a)
if(typeof u!=="string")throw H.d(H.bW(a))
return u},
P:function(a){return H.cB(a)+H.bs(H.I(a),0,null)},
cB:function(a){var u,t,s,r,q,p,o,n=J.q(a),m=n.constructor
if(typeof m=="function"){u=m.name
t=typeof u==="string"?u:null}else t=null
s=t==null
if(s||n===C.r||!!n.$iQ){r=C.f(a)
if(s)t=r
if(r==="Object"){q=a.constructor
if(typeof q=="function"){p=String(q).match(/^\s*function\s*([\w$]*)\s*\(/)
o=p==null?null:p[1]
if(typeof o==="string"&&/^\w+$/.test(o))t=o}}return t}t=t
return H.Z(t.length>1&&C.d.M(t,0)===36?C.d.G(t,1):t)},
d2:function(a){throw H.d(H.bW(a))},
l:function(a,b){if(a==null)J.bg(a)
throw H.d(H.c_(a,b))},
c_:function(a,b){var u,t,s="index"
if(typeof b!=="number"||Math.floor(b)!==b)return new P.v(!0,b,s,null)
u=J.bg(a)
if(!(b<0)){if(typeof u!=="number")return H.d2(u)
t=b>=u}else t=!0
if(t)return P.bK(b,a,s,null,u)
return P.bn(b,s)},
bW:function(a){return new P.v(!0,a,null,null)},
d:function(a){var u
if(a==null)a=new P.a3()
u=new Error()
u.dartException=a
if("defineProperty" in Object){Object.defineProperty(u,"message",{get:H.cb})
u.name=""}else u.toString=H.cb
return u},
cb:function(){return J.ai(this.dartException)},
df:function(a){throw H.d(a)},
dd:function(a){throw H.d(P.bD(a))},
o:function(a){var u,t,s,r,q,p
a=H.db(a.replace(String({}),'$receiver$'))
u=a.match(/\\\$[a-zA-Z]+\\\$/g)
if(u==null)u=H.bx([],[P.m])
t=u.indexOf("\\$arguments\\$")
s=u.indexOf("\\$argumentsExpr\\$")
r=u.indexOf("\\$expr\\$")
q=u.indexOf("\\$method\\$")
p=u.indexOf("\\$receiver\\$")
return new H.aM(a.replace(new RegExp('\\\\\\$arguments\\\\\\$','g'),'((?:x|[^x])*)').replace(new RegExp('\\\\\\$argumentsExpr\\\\\\$','g'),'((?:x|[^x])*)').replace(new RegExp('\\\\\\$expr\\\\\\$','g'),'((?:x|[^x])*)').replace(new RegExp('\\\\\\$method\\\\\\$','g'),'((?:x|[^x])*)').replace(new RegExp('\\\\\\$receiver\\\\\\$','g'),'((?:x|[^x])*)'),t,s,r,q,p)},
aN:function(a){return function($expr$){var $argumentsExpr$='$arguments$'
try{$expr$.$method$($argumentsExpr$)}catch(u){return u.message}}(a)},
bQ:function(a){return function($expr$){try{$expr$.$method$}catch(u){return u.message}}(a)},
bN:function(a,b){return new H.aG(a,b==null?null:b.method)},
bm:function(a,b){var u=b==null,t=u?null:b.method
return new H.aD(a,t,u?null:b.receiver)},
cc:function(a){var u,t,s,r,q,p,o,n,m,l,k,j,i,h,g=null,f=new H.be(a)
if(a==null)return
if(typeof a!=="object")return a
if("dartException" in a)return f.$1(a.dartException)
else if(!("message" in a))return a
u=a.message
if("number" in a&&typeof a.number=="number"){t=a.number
s=t&65535
if((C.b.O(t,16)&8191)===10)switch(s){case 438:return f.$1(H.bm(H.c(u)+" (Error "+s+")",g))
case 445:case 5007:return f.$1(H.bN(H.c(u)+" (Error "+s+")",g))}}if(a instanceof TypeError){r=$.cf()
q=$.cg()
p=$.ch()
o=$.ci()
n=$.cl()
m=$.cm()
l=$.ck()
$.cj()
k=$.co()
j=$.cn()
i=r.j(u)
if(i!=null)return f.$1(H.bm(H.u(u),i))
else{i=q.j(u)
if(i!=null){i.method="call"
return f.$1(H.bm(H.u(u),i))}else{i=p.j(u)
if(i==null){i=o.j(u)
if(i==null){i=n.j(u)
if(i==null){i=m.j(u)
if(i==null){i=l.j(u)
if(i==null){i=o.j(u)
if(i==null){i=k.j(u)
if(i==null){i=j.j(u)
h=i!=null}else h=!0}else h=!0}else h=!0}else h=!0}else h=!0}else h=!0}else h=!0
if(h)return f.$1(H.bN(H.u(u),i))}}return f.$1(new H.aP(typeof u==="string"?u:""))}if(a instanceof RangeError){if(typeof u==="string"&&u.indexOf("call stack")!==-1)return new P.a5()
u=function(b){try{return String(b)}catch(e){}return null}(a)
return f.$1(new P.v(!1,g,g,typeof u==="string"?u.replace(/^RangeError:\s*/,""):u))}if(typeof InternalError=="function"&&a instanceof InternalError)if(typeof u==="string"&&u==="too much recursion")return new P.a5()
return a},
c6:function(a){var u
if(a==null)return new H.ad(a)
u=a.$cachedTrace
if(u!=null)return u
return a.$cachedTrace=new H.ad(a)},
d6:function(a,b,c,d,e,f){H.t(a,"$ibi")
switch(H.W(b)){case 0:return a.$0()
case 1:return a.$1(c)
case 2:return a.$2(c,d)
case 3:return a.$3(c,d,e)
case 4:return a.$4(c,d,e,f)}throw H.d(new P.aX("Unsupported number of arguments for wrapped closure"))},
ag:function(a,b){var u=a.$identity
if(!!u)return u
u=function(c,d,e){return function(f,g,h,i){return e(c,d,f,g,h,i)}}(a,b,H.d6)
a.$identity=u
return u},
cv:function(a,b,c,d,e,f,g){var u,t,s,r,q,p,o,n,m=null,l=b[0],k=l.$callName,j=e?Object.create(new H.aK().constructor.prototype):Object.create(new H.a_(m,m,m,m).constructor.prototype)
j.$initialize=j.constructor
if(e)u=function static_tear_off(){this.$initialize()}
else{t=$.n
if(typeof t!=="number")return t.l()
$.n=t+1
t=new Function("a,b,c,d"+t,"this.$initialize(a,b,c,d"+t+")")
u=t}j.constructor=u
u.prototype=j
if(!e){s=H.bC(a,l,f)
s.$reflectionInfo=d}else{j.$static_name=g
s=l}r=H.cr(d,e,f)
j.$S=r
j[k]=s
for(q=s,p=1;p<b.length;++p){o=b[p]
n=o.$callName
if(n!=null){o=e?o:H.bC(a,o,f)
j[n]=o}if(p===c){o.$reflectionInfo=d
q=o}}j.$C=q
j.$R=l.$R
j.$D=l.$D
return u},
cr:function(a,b,c){var u
if(typeof a=="number")return function(d,e){return function(){return d(e)}}(H.d1,a)
if(typeof a=="function")if(b)return a
else{u=c?H.bB:H.bh
return function(d,e){return function(){return d.apply({$receiver:e(this)},arguments)}}(a,u)}throw H.d("Error in functionType of tearoff")},
cs:function(a,b,c,d){var u=H.bh
switch(b?-1:a){case 0:return function(e,f){return function(){return f(this)[e]()}}(c,u)
case 1:return function(e,f){return function(g){return f(this)[e](g)}}(c,u)
case 2:return function(e,f){return function(g,h){return f(this)[e](g,h)}}(c,u)
case 3:return function(e,f){return function(g,h,i){return f(this)[e](g,h,i)}}(c,u)
case 4:return function(e,f){return function(g,h,i,j){return f(this)[e](g,h,i,j)}}(c,u)
case 5:return function(e,f){return function(g,h,i,j,k){return f(this)[e](g,h,i,j,k)}}(c,u)
default:return function(e,f){return function(){return e.apply(f(this),arguments)}}(d,u)}},
bC:function(a,b,c){var u,t,s,r,q,p,o
if(c)return H.cu(a,b)
u=b.$stubName
t=b.length
s=a[u]
r=b==null?s==null:b===s
q=!r||t>=27
if(q)return H.cs(t,!r,u,b)
if(t===0){r=$.n
if(typeof r!=="number")return r.l()
$.n=r+1
p="self"+r
r="return function(){var "+p+" = this."
q=$.K
return new Function(r+H.c(q==null?$.K=H.an("self"):q)+";return "+p+"."+H.c(u)+"();}")()}o="abcdefghijklmnopqrstuvwxyz".split("").splice(0,t).join(",")
r=$.n
if(typeof r!=="number")return r.l()
$.n=r+1
o+=r
r="return function("+o+"){return this."
q=$.K
return new Function(r+H.c(q==null?$.K=H.an("self"):q)+"."+H.c(u)+"("+o+");}")()},
ct:function(a,b,c,d){var u=H.bh,t=H.bB
switch(b?-1:a){case 0:throw H.d(new H.aI("Intercepted function with no arguments."))
case 1:return function(e,f,g){return function(){return f(this)[e](g(this))}}(c,u,t)
case 2:return function(e,f,g){return function(h){return f(this)[e](g(this),h)}}(c,u,t)
case 3:return function(e,f,g){return function(h,i){return f(this)[e](g(this),h,i)}}(c,u,t)
case 4:return function(e,f,g){return function(h,i,j){return f(this)[e](g(this),h,i,j)}}(c,u,t)
case 5:return function(e,f,g){return function(h,i,j,k){return f(this)[e](g(this),h,i,j,k)}}(c,u,t)
case 6:return function(e,f,g){return function(h,i,j,k,l){return f(this)[e](g(this),h,i,j,k,l)}}(c,u,t)
default:return function(e,f,g,h){return function(){h=[g(this)]
Array.prototype.push.apply(h,arguments)
return e.apply(f(this),h)}}(d,u,t)}},
cu:function(a,b){var u,t,s,r,q,p,o,n=$.K
if(n==null)n=$.K=H.an("self")
u=$.bA
if(u==null)u=$.bA=H.an("receiver")
t=b.$stubName
s=b.length
r=a[t]
q=b==null?r==null:b===r
p=!q||s>=28
if(p)return H.ct(s,!q,t,b)
if(s===1){n="return function(){return this."+H.c(n)+"."+H.c(t)+"(this."+H.c(u)+");"
u=$.n
if(typeof u!=="number")return u.l()
$.n=u+1
return new Function(n+u+"}")()}o="abcdefghijklmnopqrstuvwxyz".split("").splice(0,s-1).join(",")
n="return function("+o+"){return this."+H.c(n)+"."+H.c(t)+"(this."+H.c(u)+", "+o+");"
u=$.n
if(typeof u!=="number")return u.l()
$.n=u+1
return new Function(n+u+"}")()},
bt:function(a,b,c,d,e,f,g){return H.cv(a,b,c,d,!!e,!!f,g)},
bh:function(a){return a.a},
bB:function(a){return a.c},
an:function(a){var u,t,s,r=new H.a_("self","target","receiver","name"),q=J.bM(Object.getOwnPropertyNames(r))
for(u=q.length,t=0;t<u;++t){s=q[t]
if(r[s]===a)return s}},
bY:function(a){if(a==null)H.cU("boolean expression must not be null")
return a},
u:function(a){if(a==null)return a
if(typeof a==="string")return a
throw H.d(H.z(a,"String"))},
dD:function(a){if(a==null)return a
if(typeof a==="number")return a
throw H.d(H.z(a,"num"))},
dy:function(a){if(a==null)return a
if(typeof a==="boolean")return a
throw H.d(H.z(a,"bool"))},
W:function(a){if(a==null)return a
if(typeof a==="number"&&Math.floor(a)===a)return a
throw H.d(H.z(a,"int"))},
da:function(a,b){throw H.d(H.z(a,H.Z(H.u(b).substring(2))))},
t:function(a,b){if(a==null)return a
if((typeof a==="object"||typeof a==="function")&&J.q(a)[b])return a
H.da(a,b)},
c0:function(a){var u
if("$S" in a){u=a.$S
if(typeof u=="number")return v.types[H.W(u)]
else return a.$S()}return},
c1:function(a,b){var u
if(typeof a=="function")return!0
u=H.c0(J.q(a))
if(u==null)return!1
return H.bS(u,null,b,null)},
k:function(a,b){var u,t
if(a==null)return a
if($.bq)return a
$.bq=!0
try{if(H.c1(a,b))return a
u=H.ah(b)
t=H.z(a,u)
throw H.d(t)}finally{$.bq=!1}},
z:function(a,b){return new H.a7("TypeError: "+P.au(a)+": type '"+H.c(H.cT(a))+"' is not a subtype of type '"+b+"'")},
cT:function(a){var u,t=J.q(a)
if(!!t.$iL){u=H.c0(t)
if(u!=null)return H.ah(u)
return"Closure"}return H.P(a)},
cU:function(a){throw H.d(new H.aS(a))},
de:function(a){throw H.d(new P.aq(a))},
c3:function(a){return v.getIsolateTag(a)},
bx:function(a,b){a.$ti=b
return a},
I:function(a){if(a==null)return
return a.$ti},
dB:function(a,b,c){return H.Y(a["$a"+H.c(c)],H.I(b))},
c4:function(a,b,c,d){var u=H.Y(a["$a"+H.c(c)],H.I(b))
return u==null?null:u[d]},
V:function(a,b){var u=H.I(a)
return u==null?null:u[b]},
ah:function(a){return H.A(a,null)},
A:function(a,b){var u,t
if(a==null)return"dynamic"
if(a===-1)return"void"
if(typeof a==="object"&&a!==null&&a.constructor===Array)return H.Z(a[0].name)+H.bs(a,1,b)
if(typeof a=="function")return H.Z(a.name)
if(a===-2)return"dynamic"
if(typeof a==="number"){H.W(a)
if(b==null||a<0||a>=b.length)return"unexpected-generic-index:"+a
u=b.length
t=u-a-1
if(t<0||t>=u)return H.l(b,t)
return H.c(b[t])}if('func' in a)return H.cM(a,b)
if('futureOr' in a)return"FutureOr<"+H.A("type" in a?a.type:null,b)+">"
return"unknown-reified-type"},
cM:function(a,a0){var u,t,s,r,q,p,o,n,m,l,k,j,i,h,g,f,e,d,c,b=", "
if("bounds" in a){u=a.bounds
if(a0==null){a0=H.bx([],[P.m])
t=null}else t=a0.length
s=a0.length
for(r=u.length,q=r;q>0;--q)C.i.E(a0,"T"+(s+q))
for(p="<",o="",q=0;q<r;++q,o=b){p+=o
n=a0.length
m=n-q-1
if(m<0)return H.l(a0,m)
p=C.d.l(p,a0[m])
l=u[q]
if(l!=null&&l!==P.h)p+=" extends "+H.A(l,a0)}p+=">"}else{p=""
t=null}k=!!a.v?"void":H.A(a.ret,a0)
if("args" in a){j=a.args
for(n=j.length,i="",h="",g=0;g<n;++g,h=b){f=j[g]
i=i+h+H.A(f,a0)}}else{i=""
h=""}if("opt" in a){e=a.opt
i+=h+"["
for(n=e.length,h="",g=0;g<n;++g,h=b){f=e[g]
i=i+h+H.A(f,a0)}i+="]"}if("named" in a){d=a.named
i+=h+"{"
for(n=H.cZ(d),m=n.length,h="",g=0;g<m;++g,h=b){c=H.u(n[g])
i=i+h+H.A(d[c],a0)+(" "+H.c(c))}i+="}"}if(t!=null)a0.length=t
return p+"("+i+") => "+k},
bs:function(a,b,c){var u,t,s,r,q,p
if(a==null)return""
u=new P.a6("")
for(t=b,s="",r=!0,q="";t<a.length;++t,s=", "){u.a=q+s
p=a[t]
if(p!=null)r=!1
q=u.a+=H.A(p,c)}return"<"+u.h(0)+">"},
Y:function(a,b){if(a==null)return b
a=a.apply(null,b)
if(a==null)return
if(typeof a==="object"&&a!==null&&a.constructor===Array)return a
if(typeof a=="function")return a.apply(null,b)
return b},
cY:function(a,b,c,d){var u,t
if(a==null)return!1
u=H.I(a)
t=J.q(a)
if(t[b]==null)return!1
return H.bV(H.Y(t[d],u),null,c,null)},
dx:function(a,b,c,d){if(a==null)return a
if(H.cY(a,b,c,d))return a
throw H.d(H.z(a,function(e,f){return e.replace(/[^<,> ]+/g,function(g){return f[g]||g})}(H.Z(b.substring(2))+H.bs(c,0,null),v.mangledGlobalNames)))},
U:function(a,b,c,d,e){if(!H.j(a,null,b,null))H.dg("TypeError: "+H.c(c)+H.ah(a)+H.c(d)+H.ah(b)+H.c(e))},
dg:function(a){throw H.d(new H.a7(H.u(a)))},
bV:function(a,b,c,d){var u,t
if(c==null)return!0
if(a==null){u=c.length
for(t=0;t<u;++t)if(!H.j(null,null,c[t],d))return!1
return!0}u=a.length
for(t=0;t<u;++t)if(!H.j(a[t],b,c[t],d))return!1
return!0},
dz:function(a,b,c){return a.apply(b,H.Y(J.q(b)["$a"+H.c(c)],H.I(b)))},
c7:function(a){var u
if(typeof a==="number")return!1
if('futureOr' in a){u="type" in a?a.type:null
return a==null||a.name==="h"||a.name==="i"||a===-1||a===-2||H.c7(u)}return!1},
bZ:function(a,b){var u,t
if(a==null)return b==null||b.name==="h"||b.name==="i"||b===-1||b===-2||H.c7(b)
if(b==null||b===-1||b.name==="h"||b===-2)return!0
if(typeof b=="object"){if('futureOr' in b)if(H.bZ(a,"type" in b?b.type:null))return!0
if('func' in b)return H.c1(a,b)}u=J.q(a).constructor
t=H.I(a)
if(t!=null){t=t.slice()
t.splice(0,0,u)
u=t}return H.j(u,null,b,null)},
H:function(a,b){if(a!=null&&!H.bZ(a,b))throw H.d(H.z(a,H.ah(b)))
return a},
j:function(a,b,c,d){var u,t,s,r,q,p,o,n,m,l=null
if(a===c)return!0
if(c==null||c===-1||c.name==="h"||c===-2)return!0
if(a===-2)return!0
if(a==null||a===-1||a.name==="h"||a===-2){if(typeof c==="number")return!1
if('futureOr' in c)return H.j(a,b,"type" in c?c.type:l,d)
return!1}if(typeof a==="number")return H.j(b[H.W(a)],b,c,d)
if(typeof c==="number")return!1
if(a.name==="i")return!0
u=typeof a==="object"&&a!==null&&a.constructor===Array
t=u?a[0]:a
if('futureOr' in c){s="type" in c?c.type:l
if('futureOr' in a)return H.j("type" in a?a.type:l,b,s,d)
else if(H.j(a,b,s,d))return!0
else{if(!('$i'+"cy" in t.prototype))return!1
r=t.prototype["$a"+"cy"]
q=H.Y(r,u?a.slice(1):l)
return H.j(typeof q==="object"&&q!==null&&q.constructor===Array?q[0]:l,b,s,d)}}if('func' in c)return H.bS(a,b,c,d)
if('func' in a)return c.name==="bi"
p=typeof c==="object"&&c!==null&&c.constructor===Array
o=p?c[0]:c
if(o!==t){n=o.name
if(!('$i'+n in t.prototype))return!1
m=t.prototype["$a"+n]}else m=l
if(!p)return!0
u=u?a.slice(1):l
p=c.slice(1)
return H.bV(H.Y(m,u),b,p,d)},
bS:function(a,b,c,d){var u,t,s,r,q,p,o,n,m,l,k,j,i,h,g
if(!('func' in a))return!1
if("bounds" in a){if(!("bounds" in c))return!1
u=a.bounds
t=c.bounds
if(u.length!==t.length)return!1
b=b==null?u:u.concat(b)
d=d==null?t:t.concat(d)}else if("bounds" in c)return!1
if(!H.j(a.ret,b,c.ret,d))return!1
s=a.args
r=c.args
q=a.opt
p=c.opt
o=s!=null?s.length:0
n=r!=null?r.length:0
m=q!=null?q.length:0
l=p!=null?p.length:0
if(o>n)return!1
if(o+m<n+l)return!1
for(k=0;k<o;++k)if(!H.j(r[k],d,s[k],b))return!1
for(j=k,i=0;j<n;++i,++j)if(!H.j(r[j],d,q[i],b))return!1
for(j=0;j<l;++i,++j)if(!H.j(p[j],d,q[i],b))return!1
h=a.named
g=c.named
if(g==null)return!0
if(h==null)return!1
return H.d9(h,b,g,d)},
d9:function(a,b,c,d){var u,t,s,r=Object.getOwnPropertyNames(c)
for(u=r.length,t=0;t<u;++t){s=r[t]
if(!Object.hasOwnProperty.call(a,s))return!1
if(!H.j(c[s],d,a[s],b))return!1}return!0},
dA:function(a,b,c){Object.defineProperty(a,b,{value:c,enumerable:false,writable:true,configurable:true})},
d7:function(a){var u,t,s,r,q=H.u($.c5.$1(a)),p=$.b5[q]
if(p!=null){Object.defineProperty(a,v.dispatchPropertyName,{value:p,enumerable:false,writable:true,configurable:true})
return p.i}u=$.ba[q]
if(u!=null)return u
t=v.interceptorsByTag[q]
if(t==null){q=H.u($.bU.$2(a,q))
if(q!=null){p=$.b5[q]
if(p!=null){Object.defineProperty(a,v.dispatchPropertyName,{value:p,enumerable:false,writable:true,configurable:true})
return p.i}u=$.ba[q]
if(u!=null)return u
t=v.interceptorsByTag[q]}}if(t==null)return
u=t.prototype
s=q[0]
if(s==="!"){p=H.bd(u)
$.b5[q]=p
Object.defineProperty(a,v.dispatchPropertyName,{value:p,enumerable:false,writable:true,configurable:true})
return p.i}if(s==="~"){$.ba[q]=u
return u}if(s==="-"){r=H.bd(u)
Object.defineProperty(Object.getPrototypeOf(a),v.dispatchPropertyName,{value:r,enumerable:false,writable:true,configurable:true})
return r.i}if(s==="+")return H.c9(a,u)
if(s==="*")throw H.d(P.bR(q))
if(v.leafTags[q]===true){r=H.bd(u)
Object.defineProperty(Object.getPrototypeOf(a),v.dispatchPropertyName,{value:r,enumerable:false,writable:true,configurable:true})
return r.i}else return H.c9(a,u)},
c9:function(a,b){var u=Object.getPrototypeOf(a)
Object.defineProperty(u,v.dispatchPropertyName,{value:J.bw(b,u,null,null),enumerable:false,writable:true,configurable:true})
return b},
bd:function(a){return J.bw(a,!1,null,!!a.$ibl)},
d8:function(a,b,c){var u=b.prototype
if(v.leafTags[a]===true)return H.bd(u)
else return J.bw(u,c,null,null)},
d4:function(){if(!0===$.bv)return
$.bv=!0
H.d5()},
d5:function(){var u,t,s,r,q,p,o,n
$.b5=Object.create(null)
$.ba=Object.create(null)
H.d3()
u=v.interceptorsByTag
t=Object.getOwnPropertyNames(u)
if(typeof window!="undefined"){window
s=function(){}
for(r=0;r<t.length;++r){q=t[r]
p=$.ca.$1(q)
if(p!=null){o=H.d8(q,u[q],p)
if(o!=null){Object.defineProperty(p,v.dispatchPropertyName,{value:o,enumerable:false,writable:true,configurable:true})
s.prototype=p}}}}for(r=0;r<t.length;++r){q=t[r]
if(/^[A-Za-z_]/.test(q)){n=u[q]
u["!"+q]=n
u["~"+q]=n
u["-"+q]=n
u["+"+q]=n
u["*"+q]=n}}},
d3:function(){var u,t,s,r,q,p,o=C.k()
o=H.G(C.l,H.G(C.m,H.G(C.h,H.G(C.h,H.G(C.n,H.G(C.o,H.G(C.p(C.f),o)))))))
if(typeof dartNativeDispatchHooksTransformer!="undefined"){u=dartNativeDispatchHooksTransformer
if(typeof u=="function")u=[u]
if(u.constructor==Array)for(t=0;t<u.length;++t){s=u[t]
if(typeof s=="function")o=s(o)||o}}r=o.getTag
q=o.getUnknownTag
p=o.prototypeForTag
$.c5=new H.b7(r)
$.bU=new H.b8(q)
$.ca=new H.b9(p)},
G:function(a,b){return a(b)||b},
dc:function(a,b,c){var u=a.indexOf(b,c)
return u>=0},
db:function(a){if(/[[\]{}()*+?.\\^$|]/.test(a))return a.replace(/[[\]{}()*+?.\\^$|]/g,"\\$&")
return a},
aM:function aM(a,b,c,d,e,f){var _=this
_.a=a
_.b=b
_.c=c
_.d=d
_.e=e
_.f=f},
aG:function aG(a,b){this.a=a
this.b=b},
aD:function aD(a,b,c){this.a=a
this.b=b
this.c=c},
aP:function aP(a){this.a=a},
be:function be(a){this.a=a},
ad:function ad(a){this.a=a
this.b=null},
L:function L(){},
aL:function aL(){},
aK:function aK(){},
a_:function a_(a,b,c,d){var _=this
_.a=a
_.b=b
_.c=c
_.d=d},
a7:function a7(a){this.a=a},
aI:function aI(a){this.a=a},
aS:function aS(a){this.a=a},
b7:function b7(a){this.a=a},
b8:function b8(a){this.a=a},
b9:function b9(a){this.a=a},
cZ:function(a){return J.cz(a?Object.keys(a):[],null)},
dh:function(a){return v.mangledGlobalNames[a]}},J={
bw:function(a,b,c,d){return{i:a,p:b,e:c,x:d}},
bu:function(a){var u,t,s,r,q=a[v.dispatchPropertyName]
if(q==null)if($.bv==null){H.d4()
q=a[v.dispatchPropertyName]}if(q!=null){u=q.p
if(!1===u)return q.i
if(!0===u)return a
t=Object.getPrototypeOf(a)
if(u===t)return q.i
if(q.e===t)throw H.d(P.bR("Return interceptor for "+H.c(u(a,q))))}s=a.constructor
r=s==null?null:s[$.by()]
if(r!=null)return r
r=H.d7(a)
if(r!=null)return r
if(typeof a=="function")return C.t
u=Object.getPrototypeOf(a)
if(u==null)return C.j
if(u===Object.prototype)return C.j
if(typeof s=="function"){Object.defineProperty(s,$.by(),{value:C.e,enumerable:false,writable:true,configurable:true})
return C.e}return C.e},
cz:function(a,b){return J.bM(H.bx(a,[b]))},
bM:function(a){a.fixed$length=Array
return a},
q:function(a){if(typeof a=="number"){if(Math.floor(a)==a)return J.a0.prototype
return J.aA.prototype}if(typeof a=="string")return J.D.prototype
if(a==null)return J.aB.prototype
if(typeof a=="boolean")return J.az.prototype
if(a.constructor==Array)return J.x.prototype
if(typeof a!="object"){if(typeof a=="function")return J.E.prototype
return a}if(a instanceof P.h)return a
return J.bu(a)},
c2:function(a){if(typeof a=="string")return J.D.prototype
if(a==null)return a
if(a.constructor==Array)return J.x.prototype
if(typeof a!="object"){if(typeof a=="function")return J.E.prototype
return a}if(a instanceof P.h)return a
return J.bu(a)},
d_:function(a){if(a==null)return a
if(a.constructor==Array)return J.x.prototype
if(typeof a!="object"){if(typeof a=="function")return J.E.prototype
return a}if(a instanceof P.h)return a
return J.bu(a)},
d0:function(a){if(typeof a=="string")return J.D.prototype
if(a==null)return a
if(!(a instanceof P.h))return J.Q.prototype
return a},
bf:function(a,b,c){return J.d0(a).T(a,b,c)},
cp:function(a){return J.d_(a).gv(a)},
bg:function(a){return J.c2(a).gi(a)},
ai:function(a){return J.q(a).h(a)},
e:function e(){},
az:function az(){},
aB:function aB(){},
a1:function a1(){},
aH:function aH(){},
Q:function Q(){},
E:function E(){},
x:function x(a){this.$ti=a},
bj:function bj(a){this.$ti=a},
al:function al(a,b,c){var _=this
_.a=a
_.b=b
_.c=0
_.d=null
_.$ti=c},
aC:function aC(){},
a0:function a0(){},
aA:function aA(){},
D:function D(){}},P={
cG:function(){var u,t,s={}
if(self.scheduleImmediate!=null)return P.cV()
if(self.MutationObserver!=null&&self.document!=null){u=self.document.createElement("div")
t=self.document.createElement("span")
s.a=null
new self.MutationObserver(H.ag(new P.aU(s),1)).observe(u,{childList:true})
return new P.aT(s,u,t)}else if(self.setImmediate!=null)return P.cW()
return P.cX()},
cH:function(a){self.scheduleImmediate(H.ag(new P.aV(H.k(a,{func:1,ret:-1})),0))},
cI:function(a){self.setImmediate(H.ag(new P.aW(H.k(a,{func:1,ret:-1})),0))},
cJ:function(a){P.bo(C.q,H.k(a,{func:1,ret:-1}))},
bo:function(a,b){var u=C.b.m(a.a,1000)
return P.cK(u<0?0:u,b)},
bP:function(a,b){var u=C.b.m(a.a,1000)
return P.cL(u<0?0:u,b)},
cK:function(a,b){var u=new P.ae()
u.K(a,b)
return u},
cL:function(a,b){var u=new P.ae()
u.L(a,b)
return u},
cO:function(){var u,t
for(;u=$.S,u!=null;){$.R=null
t=u.b
$.S=t
if(t==null)$.b3=null
u.a.$0()}},
cS:function(){$.br=!0
try{P.cO()}finally{$.R=null
$.br=!1
if($.S!=null)$.bz().$1(P.bX())}},
cR:function(a){var u,t,s=$.S
if(s==null){$.S=$.b3=new P.a8(a)
if(!$.br)$.bz().$1(P.bX())
$.R=$.b3
return}u=new P.a8(a)
t=$.R
if(t==null){u.b=s
$.S=$.R=u}else{u.b=t.b
$.R=t.b=u
if(u.b==null)$.b3=u}},
cE:function(a,b){var u=$.p
if(u===C.c)return P.bo(a,H.k(b,{func:1,ret:-1}))
return P.bo(a,H.k(u.R(b),{func:1,ret:-1}))},
cF:function(a,b){var u=$.p
if(u===C.c)return P.bP(a,H.k(b,{func:1,ret:-1,args:[P.r]}))
return P.bP(a,H.k(u.S(b,P.r),{func:1,ret:-1,args:[P.r]}))},
bT:function(a,b,c,d,e){var u={}
u.a=d
P.cR(new P.b4(u,e))},
cP:function(a,b,c,d,e){var u,t=$.p
if(t===c)return d.$0()
$.p=c
u=t
try{t=d.$0()
return t}finally{$.p=u}},
cQ:function(a,b,c,d,e,f,g){var u,t=$.p
if(t===c)return d.$1(e)
$.p=c
u=t
try{t=d.$1(e)
return t}finally{$.p=u}},
aU:function aU(a){this.a=a},
aT:function aT(a,b,c){this.a=a
this.b=b
this.c=c},
aV:function aV(a){this.a=a},
aW:function aW(a){this.a=a},
ae:function ae(){this.c=0},
b1:function b1(a,b){this.a=a
this.b=b},
b0:function b0(a,b,c,d){var _=this
_.a=a
_.b=b
_.c=c
_.d=d},
a8:function a8(a){this.a=a
this.b=null},
r:function r(){},
b2:function b2(){},
b4:function b4(a,b){this.a=a
this.b=b},
aY:function aY(){},
aZ:function aZ(a,b){this.a=a
this.b=b},
b_:function b_(a,b,c){this.a=a
this.b=b
this.c=c},
bL:function(a,b,c){var u,t
if(P.cN(a))return b+"..."+c
u=new P.a6(b)
C.i.E($.T,a)
try{t=u
t.a=P.cD(t.a,a,", ")}finally{if(0>=$.T.length)return H.l($.T,-1)
$.T.pop()}u.a+=c
t=u.a
return t.charCodeAt(0)==0?t:t},
cN:function(a){var u,t
for(u=$.T.length,t=0;t<u;++t)if(a===$.T[t])return!0
return!1},
aE:function aE(){},
F:function F(){},
aa:function aa(){},
cx:function(a){if(a instanceof H.L)return a.h(0)
return"Instance of '"+H.c(H.P(a))+"'"},
cD:function(a,b,c){var u=J.cp(b)
if(!u.p())return a
if(c.length===0){do a+=H.c(u.gn())
while(u.p())}else{a+=H.c(u.gn())
for(;u.p();)a=a+c+H.c(u.gn())}return a},
bJ:function(a){return new P.M(1e6*a)},
au:function(a){if(typeof a==="number"||typeof a==="boolean"||null==a)return J.ai(a)
if(typeof a==="string")return JSON.stringify(a)
return P.cx(a)},
cq:function(a,b,c){return new P.v(!0,a,b,c)},
bn:function(a,b){return new P.a4(null,null,!0,a,b,"Value not in range")},
cC:function(a,b,c,d,e){return new P.a4(b,c,!0,a,d,"Invalid value")},
bK:function(a,b,c,d,e){var u=e==null?J.bg(b):e
return new P.ax(u,!0,a,c,"Index out of range")},
aR:function(a){return new P.aQ(a)},
bR:function(a){return new P.aO(a)},
bD:function(a){return new P.ao(a)},
af:function af(){},
b6:function b6(){},
M:function M(a){this.a=a},
as:function as(){},
at:function at(){},
N:function N(){},
am:function am(){},
a3:function a3(){},
v:function v(a,b,c,d){var _=this
_.a=a
_.b=b
_.c=c
_.d=d},
a4:function a4(a,b,c,d,e,f){var _=this
_.e=a
_.f=b
_.a=c
_.b=d
_.c=e
_.d=f},
ax:function ax(a,b,c,d,e){var _=this
_.f=a
_.a=b
_.b=c
_.c=d
_.d=e},
aQ:function aQ(a){this.a=a},
aO:function aO(a){this.a=a},
ao:function ao(a){this.a=a},
a5:function a5(){},
aq:function aq(a){this.a=a},
aX:function aX(a){this.a=a},
J:function J(){},
y:function y(){},
i:function i(){},
X:function X(){},
h:function h(){},
m:function m(){},
a6:function a6(a){this.a=a},
bI:function(){var u=$.bH
return u==null?$.bH=J.bf(window.navigator.userAgent,"Opera",0):u},
cw:function(){var u,t=$.bE
if(t!=null)return t
u=$.bF
if(u==null?$.bF=J.bf(window.navigator.userAgent,"Firefox",0):u)t="-moz-"
else{u=$.bG
if(u==null)u=$.bG=!H.bY(P.bI())&&J.bf(window.navigator.userAgent,"Trident/",0)
if(u)t="-ms-"
else t=H.bY(P.bI())?"-o-":"-webkit-"}return $.bE=t}},W={b:function b(){},aj:function aj(){},ak:function ak(){},w:function w(){},B:function B(){},ap:function ap(){},ar:function ar(){},bp:function bp(a,b){this.a=a
this.$ti=b},a:function a(){},C:function C(){},aw:function aw(){},f:function f(){},a2:function a2(){},aJ:function aJ(){},O:function O(){},av:function av(a,b,c){var _=this
_.a=a
_.b=b
_.c=-1
_.d=null
_.$ti=c},a9:function a9(){},ab:function ab(){},ac:function ac(){}},F={
c8:function(){var u,t=".screen",s="The type argument '",r="' is not a subtype of the type variable bound '",q="' of type variable 'T' in 'querySelectorAll'.",p="opacity",o={},n=W.a,m=document
H.U(n,n,s,r,q)
u=m.querySelectorAll(t)
if(0>=u.length)return H.l(u,0)
u=H.t(u[0],"$ia").style
C.a.q(u,(u&&C.a).k(u,p),"1.0","")
H.U(n,n,s,r,q)
u=m.querySelectorAll(t)
if(1>=u.length)return H.l(u,1)
u=H.t(u[1],"$ia").style
C.a.q(u,(u&&C.a).k(u,p),"0.0","")
H.U(n,n,s,r,q)
u=m.querySelectorAll(t)
if(2>=u.length)return H.l(u,2)
u=H.t(u[2],"$ia").style
C.a.q(u,(u&&C.a).k(u,p),"0.0","")
H.U(n,n,s,r,q)
m=m.querySelectorAll(t)
if(3>=m.length)return H.l(m,3)
m=H.t(m[3],"$ia").style
C.a.q(m,(m&&C.a).k(m,p),"0.0","")
o.a=0
P.cE(P.bJ(2),new F.bc(o,4))},
bc:function bc(a,b){this.a=a
this.b=b},
bb:function bb(a,b){this.a=a
this.b=b}}
var w=[C,H,J,P,W,F]
hunkHelpers.setFunctionNamesIfNecessary(w)
var $={}
H.bk.prototype={}
J.e.prototype={
h:function(a){return"Instance of '"+H.c(H.P(a))+"'"}}
J.az.prototype={
h:function(a){return String(a)},
$iaf:1}
J.aB.prototype={
h:function(a){return"null"}}
J.a1.prototype={
h:function(a){return String(a)}}
J.aH.prototype={}
J.Q.prototype={}
J.E.prototype={
h:function(a){var u=a[$.ce()]
if(u==null)return this.I(a)
return"JavaScript function for "+H.c(J.ai(u))},
$S:function(){return{func:1,opt:[,,,,,,,,,,,,,,,,]}},
$ibi:1}
J.x.prototype={
E:function(a,b){H.H(b,H.V(a,0))
if(!!a.fixed$length)H.df(P.aR("add"))
a.push(b)},
h:function(a){return P.bL(a,"[","]")},
gv:function(a){return new J.al(a,a.length,[H.V(a,0)])},
gi:function(a){return a.length},
$iay:1,
$iy:1}
J.bj.prototype={}
J.al.prototype={
gn:function(){return this.d},
p:function(){var u,t=this,s=t.a,r=s.length
if(t.b!==r)throw H.d(H.dd(s))
u=t.c
if(u>=r){t.sB(null)
return!1}t.sB(s[u]);++t.c
return!0},
sB:function(a){this.d=H.H(a,H.V(this,0))}}
J.aC.prototype={
h:function(a){if(a===0&&1/a<0)return"-0.0"
else return""+a},
J:function(a,b){if((a|0)===a)if(b>=1||b<-1)return a/b|0
return this.D(a,b)},
m:function(a,b){return(a|0)===a?a/b|0:this.D(a,b)},
D:function(a,b){var u=a/b
if(u>=-2147483648&&u<=2147483647)return u|0
if(u>0){if(u!==1/0)return Math.floor(u)}else if(u>-1/0)return Math.ceil(u)
throw H.d(P.aR("Result of truncating division is "+H.c(u)+": "+H.c(a)+" ~/ "+b))},
O:function(a,b){var u
if(a>0)u=this.N(a,b)
else{u=b>31?31:b
u=a>>u>>>0}return u},
N:function(a,b){return b>31?0:a>>>b},
$iX:1}
J.a0.prototype={$iJ:1}
J.aA.prototype={}
J.D.prototype={
M:function(a,b){if(b>=a.length)throw H.d(H.c_(a,b))
return a.charCodeAt(b)},
l:function(a,b){if(typeof b!=="string")throw H.d(P.cq(b,null,null))
return a+b},
G:function(a,b){var u=a.length
if(b>u)throw H.d(P.bn(b,null))
if(u>u)throw H.d(P.bn(u,null))
return a.substring(b,u)},
T:function(a,b,c){var u=a.length
if(c>u)throw H.d(P.cC(c,0,u,null,null))
return H.dc(a,b,c)},
h:function(a){return a},
gi:function(a){return a.length},
$icA:1,
$im:1}
H.aF.prototype={
gn:function(){return this.d},
p:function(){var u,t=this,s=t.a,r=J.c2(s),q=r.gi(s)
if(t.b!==q)throw H.d(P.bD(s))
u=t.c
if(u>=q){t.sA(null)
return!1}t.sA(r.F(s,u));++t.c
return!0},
sA:function(a){this.d=H.H(a,H.V(this,0))}}
H.aM.prototype={
j:function(a){var u,t,s=this,r=new RegExp(s.a).exec(a)
if(r==null)return
u=Object.create(null)
t=s.b
if(t!==-1)u.arguments=r[t+1]
t=s.c
if(t!==-1)u.argumentsExpr=r[t+1]
t=s.d
if(t!==-1)u.expr=r[t+1]
t=s.e
if(t!==-1)u.method=r[t+1]
t=s.f
if(t!==-1)u.receiver=r[t+1]
return u}}
H.aG.prototype={
h:function(a){var u=this.b
if(u==null)return"NoSuchMethodError: "+H.c(this.a)
return"NoSuchMethodError: method not found: '"+u+"' on null"}}
H.aD.prototype={
h:function(a){var u,t=this,s="NoSuchMethodError: method not found: '",r=t.b
if(r==null)return"NoSuchMethodError: "+H.c(t.a)
u=t.c
if(u==null)return s+r+"' ("+H.c(t.a)+")"
return s+r+"' on '"+u+"' ("+H.c(t.a)+")"}}
H.aP.prototype={
h:function(a){var u=this.a
return u.length===0?"Error":"Error: "+u}}
H.be.prototype={
$1:function(a){if(!!J.q(a).$iN)if(a.$thrownJsError==null)a.$thrownJsError=this.a
return a},
$S:3}
H.ad.prototype={
h:function(a){var u,t=this.b
if(t!=null)return t
t=this.a
u=t!==null&&typeof t==="object"?t.stack:null
return this.b=u==null?"":u},
$ibO:1}
H.L.prototype={
h:function(a){var u=H.P(this).trim()
return"Closure '"+u+"'"},
$ibi:1,
gW:function(){return this},
$C:"$1",
$R:1,
$D:null}
H.aL.prototype={}
H.aK.prototype={
h:function(a){var u=this.$static_name
if(u==null)return"Closure of unknown static method"
return"Closure '"+H.Z(u)+"'"}}
H.a_.prototype={
h:function(a){var u=this.c
if(u==null)u=this.a
return"Closure '"+H.c(this.d)+"' of "+("Instance of '"+H.c(H.P(u))+"'")}}
H.a7.prototype={
h:function(a){return this.a}}
H.aI.prototype={
h:function(a){return"RuntimeError: "+this.a}}
H.aS.prototype={
h:function(a){return"Assertion failed: "+P.au(this.a)}}
H.b7.prototype={
$1:function(a){return this.a(a)},
$S:3}
H.b8.prototype={
$2:function(a,b){return this.a(a,b)}}
H.b9.prototype={
$1:function(a){return this.a(H.u(a))},
$S:5}
P.aU.prototype={
$1:function(a){var u=this.a,t=u.a
u.a=null
t.$0()},
$S:6}
P.aT.prototype={
$1:function(a){var u,t
this.a.a=H.k(a,{func:1,ret:-1})
u=this.b
t=this.c
u.firstChild?u.removeChild(t):u.appendChild(t)},
$S:7}
P.aV.prototype={
$0:function(){this.a.$0()},
$S:0}
P.aW.prototype={
$0:function(){this.a.$0()},
$S:0}
P.ae.prototype={
K:function(a,b){if(self.setTimeout!=null)self.setTimeout(H.ag(new P.b1(this,b),0),a)
else throw H.d(P.aR("`setTimeout()` not found."))},
L:function(a,b){if(self.setTimeout!=null)self.setInterval(H.ag(new P.b0(this,a,Date.now(),b),0),a)
else throw H.d(P.aR("Periodic timer."))},
$ir:1}
P.b1.prototype={
$0:function(){this.a.c=1
this.b.$0()},
$S:1}
P.b0.prototype={
$0:function(){var u,t=this,s=t.a,r=s.c+1,q=t.b
if(q>0){u=Date.now()-t.c
if(u>(r+1)*q)r=C.b.J(u,q)}s.c=r
t.d.$1(s)},
$S:0}
P.a8.prototype={}
P.r.prototype={}
P.b2.prototype={}
P.b4.prototype={
$0:function(){var u,t=this.a,s=t.a
t=s==null?t.a=new P.a3():s
s=this.b
if(s==null)throw H.d(t)
u=H.d(t)
u.stack=s.h(0)
throw u},
$S:0}
P.aY.prototype={
U:function(a){var u,t,s,r=null
H.k(a,{func:1,ret:-1})
try{if(C.c===$.p){a.$0()
return}P.cP(r,r,this,a,-1)}catch(s){u=H.cc(s)
t=H.c6(s)
P.bT(r,r,this,u,H.t(t,"$ibO"))}},
V:function(a,b,c){var u,t,s,r=null
H.k(a,{func:1,ret:-1,args:[c]})
H.H(b,c)
try{if(C.c===$.p){a.$1(b)
return}P.cQ(r,r,this,a,b,-1,c)}catch(s){u=H.cc(s)
t=H.c6(s)
P.bT(r,r,this,u,H.t(t,"$ibO"))}},
R:function(a){return new P.aZ(this,H.k(a,{func:1,ret:-1}))},
S:function(a,b){return new P.b_(this,H.k(a,{func:1,ret:-1,args:[b]}),b)}}
P.aZ.prototype={
$0:function(){return this.a.U(this.b)},
$S:1}
P.b_.prototype={
$1:function(a){var u=this.c
return this.a.V(this.b,H.H(a,u),u)},
$S:function(){return{func:1,ret:-1,args:[this.c]}}}
P.aE.prototype={$iay:1,$iy:1}
P.F.prototype={
gv:function(a){return new H.aF(a,this.gi(a),[H.c4(this,a,"F",0)])},
F:function(a,b){return this.w(a,b)},
h:function(a){return P.bL(a,"[","]")}}
P.aa.prototype={}
P.af.prototype={
h:function(a){return this?"true":"false"}}
P.b6.prototype={}
P.M.prototype={
h:function(a){var u,t,s,r=new P.at(),q=this.a
if(q<0)return"-"+new P.M(0-q).h(0)
u=r.$1(C.b.m(q,6e7)%60)
t=r.$1(C.b.m(q,1e6)%60)
s=new P.as().$1(q%1e6)
return""+C.b.m(q,36e8)+":"+H.c(u)+":"+H.c(t)+"."+H.c(s)}}
P.as.prototype={
$1:function(a){if(a>=1e5)return""+a
if(a>=1e4)return"0"+a
if(a>=1000)return"00"+a
if(a>=100)return"000"+a
if(a>=10)return"0000"+a
return"00000"+a},
$S:4}
P.at.prototype={
$1:function(a){if(a>=10)return""+a
return"0"+a},
$S:4}
P.N.prototype={}
P.am.prototype={
h:function(a){return"Assertion failed"}}
P.a3.prototype={
h:function(a){return"Throw of null."}}
P.v.prototype={
gu:function(){return"Invalid argument"+(!this.a?"(s)":"")},
gt:function(){return""},
h:function(a){var u,t,s,r,q=this,p=q.c,o=p!=null?" ("+p+")":""
p=q.d
u=p==null?"":": "+p
t=q.gu()+o+u
if(!q.a)return t
s=q.gt()
r=P.au(q.b)
return t+s+": "+r}}
P.a4.prototype={
gu:function(){return"RangeError"},
gt:function(){var u,t,s=this.e
if(s==null){s=this.f
u=s!=null?": Not less than or equal to "+H.c(s):""}else{t=this.f
if(t==null)u=": Not greater than or equal to "+H.c(s)
else if(t>s)u=": Not in range "+H.c(s)+".."+H.c(t)+", inclusive"
else u=t<s?": Valid value range is empty":": Only valid value is "+H.c(s)}return u}}
P.ax.prototype={
gu:function(){return"RangeError"},
gt:function(){var u,t=H.W(this.b)
if(typeof t!=="number")return t.X()
if(t<0)return": index must not be negative"
u=this.f
if(u===0)return": no indices are valid"
return": index should be less than "+H.c(u)},
gi:function(a){return this.f}}
P.aQ.prototype={
h:function(a){return"Unsupported operation: "+this.a}}
P.aO.prototype={
h:function(a){var u=this.a
return u!=null?"UnimplementedError: "+u:"UnimplementedError"}}
P.ao.prototype={
h:function(a){var u=this.a
if(u==null)return"Concurrent modification during iteration."
return"Concurrent modification during iteration: "+P.au(u)+"."}}
P.a5.prototype={
h:function(a){return"Stack Overflow"},
$iN:1}
P.aq.prototype={
h:function(a){var u=this.a
return u==null?"Reading static variable during its initialization":"Reading static variable '"+u+"' during its initialization"}}
P.aX.prototype={
h:function(a){return"Exception: "+this.a}}
P.J.prototype={}
P.y.prototype={$iay:1}
P.i.prototype={
h:function(a){return"null"}}
P.X.prototype={}
P.h.prototype={constructor:P.h,$ih:1,
h:function(a){return"Instance of '"+H.c(H.P(this))+"'"},
toString:function(){return this.h(this)}}
P.m.prototype={$icA:1}
P.a6.prototype={
gi:function(a){return this.a.length},
h:function(a){var u=this.a
return u.charCodeAt(0)==0?u:u}}
W.b.prototype={}
W.aj.prototype={
h:function(a){return String(a)}}
W.ak.prototype={
h:function(a){return String(a)}}
W.w.prototype={
gi:function(a){return a.length}}
W.B.prototype={
k:function(a,b){var u=$.cd(),t=u[b]
if(typeof t==="string")return t
t=this.P(a,b)
u[b]=t
return t},
P:function(a,b){var u
if(b.replace(/^-ms-/,"ms-").replace(/-([\da-z])/ig,function(c,d){return d.toUpperCase()}) in a)return b
u=P.cw()+b
if(u in a)return u
return b},
q:function(a,b,c,d){a.setProperty(b,c,d)},
gi:function(a){return a.length}}
W.ap.prototype={}
W.ar.prototype={
h:function(a){return String(a)}}
W.bp.prototype={
gi:function(a){return this.a.length},
w:function(a,b){var u=this.a
if(b<0||b>=u.length)return H.l(u,b)
return H.H(u[b],H.V(this,0))}}
W.a.prototype={
h:function(a){return a.localName},
$ia:1}
W.C.prototype={}
W.aw.prototype={
gi:function(a){return a.length}}
W.f.prototype={
h:function(a){var u=a.nodeValue
return u==null?this.H(a):u},
$if:1}
W.a2.prototype={
gi:function(a){return a.length},
w:function(a,b){if(b>>>0!==b||b>=a.length)throw H.d(P.bK(b,a,null,null,null))
return a[b]},
F:function(a,b){if(b<0||b>=a.length)return H.l(a,b)
return a[b]},
$ibl:1,
$abl:function(){return[W.f]},
$aF:function(){return[W.f]},
$iay:1,
$aay:function(){return[W.f]},
$iy:1,
$ay:function(){return[W.f]},
$aO:function(){return[W.f]}}
W.aJ.prototype={
gi:function(a){return a.length}}
W.O.prototype={
gv:function(a){return new W.av(a,a.length,[H.c4(this,a,"O",0)])}}
W.av.prototype={
p:function(){var u=this,t=u.c+1,s=u.b
if(t<s){s=u.a
if(t<0||t>=s.length)return H.l(s,t)
u.sC(s[t])
u.c=t
return!0}u.sC(null)
u.c=s
return!1},
gn:function(){return this.d},
sC:function(a){this.d=H.H(a,H.V(this,0))}}
W.a9.prototype={}
W.ab.prototype={}
W.ac.prototype={}
F.bc.prototype={
$0:function(){var u,t,s,r,q,p=this.a,o=this.b
p.a=(p.a+1)%o
u=W.a
t=document
H.U(u,u,"The type argument '","' is not a subtype of the type variable bound '","' of type variable 'T' in 'querySelectorAll'.")
t=t.querySelectorAll(".screen")
for(s=0;s<o;++s){if(s>=t.length)return H.l(t,s)
u=H.t(t[s],"$ia").style
r=s===p.a?"1.0":"0.0"
q=(u&&C.a).k(u,"opacity")
u.setProperty(q,r,"")
q=C.a.k(u,"transition")
u.setProperty(q,"transform 1s, opacity 2s","")
q=s===p.a?"1":"0"
u.zIndex=q}P.cF(P.bJ(4),new F.bb(p,o))},
$S:0}
F.bb.prototype={
$1:function(a){var u,t,s,r,q,p=this.a,o=this.b
p.a=(p.a+1)%o
u=W.a
t=document
H.U(u,u,"The type argument '","' is not a subtype of the type variable bound '","' of type variable 'T' in 'querySelectorAll'.")
t=t.querySelectorAll(".screen")
for(s=0;s<o;++s){if(s>=t.length)return H.l(t,s)
u=H.t(t[s],"$ia").style
r=s===p.a?"1.0":"0.0"
q=(u&&C.a).k(u,"opacity")
u.setProperty(q,r,"")
q=C.a.k(u,"transition")
u.setProperty(q,"transform 1s, opacity 2s","")
q=s===p.a?"1":"0"
u.zIndex=q}},
$S:8};(function aliases(){var u=J.e.prototype
u.H=u.h
u=J.a1.prototype
u.I=u.h})();(function installTearOffs(){var u=hunkHelpers._static_1,t=hunkHelpers._static_0
u(P,"cV","cH",2)
u(P,"cW","cI",2)
u(P,"cX","cJ",2)
t(P,"bX","cS",1)})();(function inheritance(){var u=hunkHelpers.mixin,t=hunkHelpers.inherit,s=hunkHelpers.inheritMany
t(P.h,null)
s(P.h,[H.bk,J.e,J.al,H.aF,H.aM,P.N,H.L,H.ad,P.ae,P.a8,P.r,P.b2,P.aa,P.F,P.af,P.X,P.M,P.a5,P.aX,P.y,P.i,P.m,P.a6,W.ap,W.O,W.av])
s(J.e,[J.az,J.aB,J.a1,J.x,J.aC,J.D,W.C,W.a9,W.ar,W.ab])
s(J.a1,[J.aH,J.Q,J.E])
t(J.bj,J.x)
s(J.aC,[J.a0,J.aA])
s(P.N,[H.aG,H.aD,H.aP,H.a7,H.aI,P.am,P.a3,P.v,P.aQ,P.aO,P.ao,P.aq])
s(H.L,[H.be,H.aL,H.b7,H.b8,H.b9,P.aU,P.aT,P.aV,P.aW,P.b1,P.b0,P.b4,P.aZ,P.b_,P.as,P.at,F.bc,F.bb])
s(H.aL,[H.aK,H.a_])
t(H.aS,P.am)
t(P.aY,P.b2)
t(P.aE,P.aa)
s(P.X,[P.b6,P.J])
s(P.v,[P.a4,P.ax])
t(W.f,W.C)
s(W.f,[W.a,W.w])
t(W.b,W.a)
s(W.b,[W.aj,W.ak,W.aw,W.aJ])
t(W.B,W.a9)
t(W.bp,P.aE)
t(W.ac,W.ab)
t(W.a2,W.ac)
u(P.aa,P.F)
u(W.a9,W.ap)
u(W.ab,P.F)
u(W.ac,W.O)})()
var v={mangledGlobalNames:{J:"int",b6:"double",X:"num",m:"String",af:"bool",i:"Null",y:"List"},mangledNames:{},getTypeFromName:getGlobalFromName,metadata:[],types:[{func:1,ret:P.i},{func:1,ret:-1},{func:1,ret:-1,args:[{func:1,ret:-1}]},{func:1,args:[,]},{func:1,ret:P.m,args:[P.J]},{func:1,args:[P.m]},{func:1,ret:P.i,args:[,]},{func:1,ret:P.i,args:[{func:1,ret:-1}]},{func:1,ret:P.i,args:[P.r]}],interceptorsByTag:null,leafTags:null};(function constants(){C.a=W.B.prototype
C.r=J.e.prototype
C.i=J.x.prototype
C.b=J.a0.prototype
C.d=J.D.prototype
C.t=J.E.prototype
C.j=J.aH.prototype
C.e=J.Q.prototype
C.f=function getTagFallback(o) {
  var s = Object.prototype.toString.call(o);
  return s.substring(8, s.length - 1);
}
C.k=function() {
  var toStringFunction = Object.prototype.toString;
  function getTag(o) {
    var s = toStringFunction.call(o);
    return s.substring(8, s.length - 1);
  }
  function getUnknownTag(object, tag) {
    if (/^HTML[A-Z].*Element$/.test(tag)) {
      var name = toStringFunction.call(object);
      if (name == "[object Object]") return null;
      return "HTMLElement";
    }
  }
  function getUnknownTagGenericBrowser(object, tag) {
    if (self.HTMLElement && object instanceof HTMLElement) return "HTMLElement";
    return getUnknownTag(object, tag);
  }
  function prototypeForTag(tag) {
    if (typeof window == "undefined") return null;
    if (typeof window[tag] == "undefined") return null;
    var constructor = window[tag];
    if (typeof constructor != "function") return null;
    return constructor.prototype;
  }
  function discriminator(tag) { return null; }
  var isBrowser = typeof navigator == "object";
  return {
    getTag: getTag,
    getUnknownTag: isBrowser ? getUnknownTagGenericBrowser : getUnknownTag,
    prototypeForTag: prototypeForTag,
    discriminator: discriminator };
}
C.p=function(getTagFallback) {
  return function(hooks) {
    if (typeof navigator != "object") return hooks;
    var ua = navigator.userAgent;
    if (ua.indexOf("DumpRenderTree") >= 0) return hooks;
    if (ua.indexOf("Chrome") >= 0) {
      function confirm(p) {
        return typeof window == "object" && window[p] && window[p].name == p;
      }
      if (confirm("Window") && confirm("HTMLElement")) return hooks;
    }
    hooks.getTag = getTagFallback;
  };
}
C.l=function(hooks) {
  if (typeof dartExperimentalFixupGetTag != "function") return hooks;
  hooks.getTag = dartExperimentalFixupGetTag(hooks.getTag);
}
C.m=function(hooks) {
  var getTag = hooks.getTag;
  var prototypeForTag = hooks.prototypeForTag;
  function getTagFixed(o) {
    var tag = getTag(o);
    if (tag == "Document") {
      if (!!o.xmlVersion) return "!Document";
      return "!HTMLDocument";
    }
    return tag;
  }
  function prototypeForTagFixed(tag) {
    if (tag == "Document") return null;
    return prototypeForTag(tag);
  }
  hooks.getTag = getTagFixed;
  hooks.prototypeForTag = prototypeForTagFixed;
}
C.o=function(hooks) {
  var userAgent = typeof navigator == "object" ? navigator.userAgent : "";
  if (userAgent.indexOf("Firefox") == -1) return hooks;
  var getTag = hooks.getTag;
  var quickMap = {
    "BeforeUnloadEvent": "Event",
    "DataTransfer": "Clipboard",
    "GeoGeolocation": "Geolocation",
    "Location": "!Location",
    "WorkerMessageEvent": "MessageEvent",
    "XMLDocument": "!Document"};
  function getTagFirefox(o) {
    var tag = getTag(o);
    return quickMap[tag] || tag;
  }
  hooks.getTag = getTagFirefox;
}
C.n=function(hooks) {
  var userAgent = typeof navigator == "object" ? navigator.userAgent : "";
  if (userAgent.indexOf("Trident/") == -1) return hooks;
  var getTag = hooks.getTag;
  var quickMap = {
    "BeforeUnloadEvent": "Event",
    "DataTransfer": "Clipboard",
    "HTMLDDElement": "HTMLElement",
    "HTMLDTElement": "HTMLElement",
    "HTMLPhraseElement": "HTMLElement",
    "Position": "Geoposition"
  };
  function getTagIE(o) {
    var tag = getTag(o);
    var newTag = quickMap[tag];
    if (newTag) return newTag;
    if (tag == "Object") {
      if (window.DataView && (o instanceof window.DataView)) return "DataView";
    }
    return tag;
  }
  function prototypeForTagIE(tag) {
    var constructor = window[tag];
    if (constructor == null) return null;
    return constructor.prototype;
  }
  hooks.getTag = getTagIE;
  hooks.prototypeForTag = prototypeForTagIE;
}
C.h=function(hooks) { return hooks; }

C.c=new P.aY()
C.q=new P.M(0)})();(function staticFields(){$.n=0
$.K=null
$.bA=null
$.bq=!1
$.c5=null
$.bU=null
$.ca=null
$.b5=null
$.ba=null
$.bv=null
$.S=null
$.b3=null
$.R=null
$.br=!1
$.p=C.c
$.T=[]
$.bH=null
$.bG=null
$.bF=null
$.bE=null})();(function lazyInitializers(){var u=hunkHelpers.lazy
u($,"dj","ce",function(){return H.c3("_$dart_dartClosure")})
u($,"dk","by",function(){return H.c3("_$dart_js")})
u($,"dl","cf",function(){return H.o(H.aN({
toString:function(){return"$receiver$"}}))})
u($,"dm","cg",function(){return H.o(H.aN({$method$:null,
toString:function(){return"$receiver$"}}))})
u($,"dn","ch",function(){return H.o(H.aN(null))})
u($,"dp","ci",function(){return H.o(function(){var $argumentsExpr$='$arguments$'
try{null.$method$($argumentsExpr$)}catch(t){return t.message}}())})
u($,"ds","cl",function(){return H.o(H.aN(void 0))})
u($,"dt","cm",function(){return H.o(function(){var $argumentsExpr$='$arguments$'
try{(void 0).$method$($argumentsExpr$)}catch(t){return t.message}}())})
u($,"dr","ck",function(){return H.o(H.bQ(null))})
u($,"dq","cj",function(){return H.o(function(){try{null.$method$}catch(t){return t.message}}())})
u($,"dv","co",function(){return H.o(H.bQ(void 0))})
u($,"du","cn",function(){return H.o(function(){try{(void 0).$method$}catch(t){return t.message}}())})
u($,"dw","bz",function(){return P.cG()})
u($,"di","cd",function(){return{}})})();(function nativeSupport(){!function(){var u=function(a){var o={}
o[a]=1
return Object.keys(hunkHelpers.convertToFastObject(o))[0]}
v.getIsolateTag=function(a){return u("___dart_"+a+v.isolateTag)}
var t="___dart_isolate_tags_"
var s=Object[t]||(Object[t]=Object.create(null))
var r="_ZxYxX"
for(var q=0;;q++){var p=u(r+"_"+q+"_")
if(!(p in s)){s[p]=1
v.isolateTag=p
break}}v.dispatchPropertyName=v.getIsolateTag("dispatch_record")}()
hunkHelpers.setOrUpdateInterceptorsByTag({ApplicationCacheErrorEvent:J.e,DOMError:J.e,ErrorEvent:J.e,Event:J.e,InputEvent:J.e,MediaError:J.e,Navigator:J.e,NavigatorConcurrentHardware:J.e,NavigatorUserMediaError:J.e,OverconstrainedError:J.e,PositionError:J.e,SensorErrorEvent:J.e,SpeechRecognitionError:J.e,SQLError:J.e,HTMLAudioElement:W.b,HTMLBRElement:W.b,HTMLBaseElement:W.b,HTMLBodyElement:W.b,HTMLButtonElement:W.b,HTMLCanvasElement:W.b,HTMLContentElement:W.b,HTMLDListElement:W.b,HTMLDataElement:W.b,HTMLDataListElement:W.b,HTMLDetailsElement:W.b,HTMLDialogElement:W.b,HTMLDivElement:W.b,HTMLEmbedElement:W.b,HTMLFieldSetElement:W.b,HTMLHRElement:W.b,HTMLHeadElement:W.b,HTMLHeadingElement:W.b,HTMLHtmlElement:W.b,HTMLIFrameElement:W.b,HTMLImageElement:W.b,HTMLInputElement:W.b,HTMLLIElement:W.b,HTMLLabelElement:W.b,HTMLLegendElement:W.b,HTMLLinkElement:W.b,HTMLMapElement:W.b,HTMLMediaElement:W.b,HTMLMenuElement:W.b,HTMLMetaElement:W.b,HTMLMeterElement:W.b,HTMLModElement:W.b,HTMLOListElement:W.b,HTMLObjectElement:W.b,HTMLOptGroupElement:W.b,HTMLOptionElement:W.b,HTMLOutputElement:W.b,HTMLParagraphElement:W.b,HTMLParamElement:W.b,HTMLPictureElement:W.b,HTMLPreElement:W.b,HTMLProgressElement:W.b,HTMLQuoteElement:W.b,HTMLScriptElement:W.b,HTMLShadowElement:W.b,HTMLSlotElement:W.b,HTMLSourceElement:W.b,HTMLSpanElement:W.b,HTMLStyleElement:W.b,HTMLTableCaptionElement:W.b,HTMLTableCellElement:W.b,HTMLTableDataCellElement:W.b,HTMLTableHeaderCellElement:W.b,HTMLTableColElement:W.b,HTMLTableElement:W.b,HTMLTableRowElement:W.b,HTMLTableSectionElement:W.b,HTMLTemplateElement:W.b,HTMLTextAreaElement:W.b,HTMLTimeElement:W.b,HTMLTitleElement:W.b,HTMLTrackElement:W.b,HTMLUListElement:W.b,HTMLUnknownElement:W.b,HTMLVideoElement:W.b,HTMLDirectoryElement:W.b,HTMLFontElement:W.b,HTMLFrameElement:W.b,HTMLFrameSetElement:W.b,HTMLMarqueeElement:W.b,HTMLElement:W.b,HTMLAnchorElement:W.aj,HTMLAreaElement:W.ak,CDATASection:W.w,CharacterData:W.w,Comment:W.w,ProcessingInstruction:W.w,Text:W.w,CSSStyleDeclaration:W.B,MSStyleCSSProperties:W.B,CSS2Properties:W.B,DOMException:W.ar,SVGAElement:W.a,SVGAnimateElement:W.a,SVGAnimateMotionElement:W.a,SVGAnimateTransformElement:W.a,SVGAnimationElement:W.a,SVGCircleElement:W.a,SVGClipPathElement:W.a,SVGDefsElement:W.a,SVGDescElement:W.a,SVGDiscardElement:W.a,SVGEllipseElement:W.a,SVGFEBlendElement:W.a,SVGFEColorMatrixElement:W.a,SVGFEComponentTransferElement:W.a,SVGFECompositeElement:W.a,SVGFEConvolveMatrixElement:W.a,SVGFEDiffuseLightingElement:W.a,SVGFEDisplacementMapElement:W.a,SVGFEDistantLightElement:W.a,SVGFEFloodElement:W.a,SVGFEFuncAElement:W.a,SVGFEFuncBElement:W.a,SVGFEFuncGElement:W.a,SVGFEFuncRElement:W.a,SVGFEGaussianBlurElement:W.a,SVGFEImageElement:W.a,SVGFEMergeElement:W.a,SVGFEMergeNodeElement:W.a,SVGFEMorphologyElement:W.a,SVGFEOffsetElement:W.a,SVGFEPointLightElement:W.a,SVGFESpecularLightingElement:W.a,SVGFESpotLightElement:W.a,SVGFETileElement:W.a,SVGFETurbulenceElement:W.a,SVGFilterElement:W.a,SVGForeignObjectElement:W.a,SVGGElement:W.a,SVGGeometryElement:W.a,SVGGraphicsElement:W.a,SVGImageElement:W.a,SVGLineElement:W.a,SVGLinearGradientElement:W.a,SVGMarkerElement:W.a,SVGMaskElement:W.a,SVGMetadataElement:W.a,SVGPathElement:W.a,SVGPatternElement:W.a,SVGPolygonElement:W.a,SVGPolylineElement:W.a,SVGRadialGradientElement:W.a,SVGRectElement:W.a,SVGScriptElement:W.a,SVGSetElement:W.a,SVGStopElement:W.a,SVGStyleElement:W.a,SVGElement:W.a,SVGSVGElement:W.a,SVGSwitchElement:W.a,SVGSymbolElement:W.a,SVGTSpanElement:W.a,SVGTextContentElement:W.a,SVGTextElement:W.a,SVGTextPathElement:W.a,SVGTextPositioningElement:W.a,SVGTitleElement:W.a,SVGUseElement:W.a,SVGViewElement:W.a,SVGGradientElement:W.a,SVGComponentTransferFunctionElement:W.a,SVGFEDropShadowElement:W.a,SVGMPathElement:W.a,Element:W.a,Window:W.C,DOMWindow:W.C,EventTarget:W.C,HTMLFormElement:W.aw,Document:W.f,DocumentFragment:W.f,HTMLDocument:W.f,ShadowRoot:W.f,XMLDocument:W.f,Attr:W.f,DocumentType:W.f,Node:W.f,NodeList:W.a2,RadioNodeList:W.a2,HTMLSelectElement:W.aJ})
hunkHelpers.setOrUpdateLeafTags({ApplicationCacheErrorEvent:true,DOMError:true,ErrorEvent:true,Event:true,InputEvent:true,MediaError:true,Navigator:true,NavigatorConcurrentHardware:true,NavigatorUserMediaError:true,OverconstrainedError:true,PositionError:true,SensorErrorEvent:true,SpeechRecognitionError:true,SQLError:true,HTMLAudioElement:true,HTMLBRElement:true,HTMLBaseElement:true,HTMLBodyElement:true,HTMLButtonElement:true,HTMLCanvasElement:true,HTMLContentElement:true,HTMLDListElement:true,HTMLDataElement:true,HTMLDataListElement:true,HTMLDetailsElement:true,HTMLDialogElement:true,HTMLDivElement:true,HTMLEmbedElement:true,HTMLFieldSetElement:true,HTMLHRElement:true,HTMLHeadElement:true,HTMLHeadingElement:true,HTMLHtmlElement:true,HTMLIFrameElement:true,HTMLImageElement:true,HTMLInputElement:true,HTMLLIElement:true,HTMLLabelElement:true,HTMLLegendElement:true,HTMLLinkElement:true,HTMLMapElement:true,HTMLMediaElement:true,HTMLMenuElement:true,HTMLMetaElement:true,HTMLMeterElement:true,HTMLModElement:true,HTMLOListElement:true,HTMLObjectElement:true,HTMLOptGroupElement:true,HTMLOptionElement:true,HTMLOutputElement:true,HTMLParagraphElement:true,HTMLParamElement:true,HTMLPictureElement:true,HTMLPreElement:true,HTMLProgressElement:true,HTMLQuoteElement:true,HTMLScriptElement:true,HTMLShadowElement:true,HTMLSlotElement:true,HTMLSourceElement:true,HTMLSpanElement:true,HTMLStyleElement:true,HTMLTableCaptionElement:true,HTMLTableCellElement:true,HTMLTableDataCellElement:true,HTMLTableHeaderCellElement:true,HTMLTableColElement:true,HTMLTableElement:true,HTMLTableRowElement:true,HTMLTableSectionElement:true,HTMLTemplateElement:true,HTMLTextAreaElement:true,HTMLTimeElement:true,HTMLTitleElement:true,HTMLTrackElement:true,HTMLUListElement:true,HTMLUnknownElement:true,HTMLVideoElement:true,HTMLDirectoryElement:true,HTMLFontElement:true,HTMLFrameElement:true,HTMLFrameSetElement:true,HTMLMarqueeElement:true,HTMLElement:false,HTMLAnchorElement:true,HTMLAreaElement:true,CDATASection:true,CharacterData:true,Comment:true,ProcessingInstruction:true,Text:true,CSSStyleDeclaration:true,MSStyleCSSProperties:true,CSS2Properties:true,DOMException:true,SVGAElement:true,SVGAnimateElement:true,SVGAnimateMotionElement:true,SVGAnimateTransformElement:true,SVGAnimationElement:true,SVGCircleElement:true,SVGClipPathElement:true,SVGDefsElement:true,SVGDescElement:true,SVGDiscardElement:true,SVGEllipseElement:true,SVGFEBlendElement:true,SVGFEColorMatrixElement:true,SVGFEComponentTransferElement:true,SVGFECompositeElement:true,SVGFEConvolveMatrixElement:true,SVGFEDiffuseLightingElement:true,SVGFEDisplacementMapElement:true,SVGFEDistantLightElement:true,SVGFEFloodElement:true,SVGFEFuncAElement:true,SVGFEFuncBElement:true,SVGFEFuncGElement:true,SVGFEFuncRElement:true,SVGFEGaussianBlurElement:true,SVGFEImageElement:true,SVGFEMergeElement:true,SVGFEMergeNodeElement:true,SVGFEMorphologyElement:true,SVGFEOffsetElement:true,SVGFEPointLightElement:true,SVGFESpecularLightingElement:true,SVGFESpotLightElement:true,SVGFETileElement:true,SVGFETurbulenceElement:true,SVGFilterElement:true,SVGForeignObjectElement:true,SVGGElement:true,SVGGeometryElement:true,SVGGraphicsElement:true,SVGImageElement:true,SVGLineElement:true,SVGLinearGradientElement:true,SVGMarkerElement:true,SVGMaskElement:true,SVGMetadataElement:true,SVGPathElement:true,SVGPatternElement:true,SVGPolygonElement:true,SVGPolylineElement:true,SVGRadialGradientElement:true,SVGRectElement:true,SVGScriptElement:true,SVGSetElement:true,SVGStopElement:true,SVGStyleElement:true,SVGElement:true,SVGSVGElement:true,SVGSwitchElement:true,SVGSymbolElement:true,SVGTSpanElement:true,SVGTextContentElement:true,SVGTextElement:true,SVGTextPathElement:true,SVGTextPositioningElement:true,SVGTitleElement:true,SVGUseElement:true,SVGViewElement:true,SVGGradientElement:true,SVGComponentTransferFunctionElement:true,SVGFEDropShadowElement:true,SVGMPathElement:true,Element:false,Window:true,DOMWindow:true,EventTarget:false,HTMLFormElement:true,Document:true,DocumentFragment:true,HTMLDocument:true,ShadowRoot:true,XMLDocument:true,Attr:true,DocumentType:true,Node:false,NodeList:true,RadioNodeList:true,HTMLSelectElement:true})})()
convertAllToFastObject(w)
convertToFastObject($);(function(a){if(typeof document==="undefined"){a(null)
return}if(typeof document.currentScript!='undefined'){a(document.currentScript)
return}var u=document.scripts
function onLoad(b){for(var s=0;s<u.length;++s)u[s].removeEventListener("load",onLoad,false)
a(b.target)}for(var t=0;t<u.length;++t)u[t].addEventListener("load",onLoad,false)})(function(a){v.currentScript=a
if(typeof dartMainRunner==="function")dartMainRunner(F.c8,[])
else F.c8([])})})()
//# sourceMappingURL=main.dart.js.map
