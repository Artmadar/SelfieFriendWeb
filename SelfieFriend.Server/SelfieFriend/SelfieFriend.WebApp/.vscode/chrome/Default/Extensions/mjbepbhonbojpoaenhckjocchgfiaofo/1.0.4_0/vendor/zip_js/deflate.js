(function(T){function p(){var b=this;b.build_tree=function(a){var B=b.dyn_tree,d=b.stat_desc.static_tree,f=b.stat_desc.elems,n,C=-1,t;a.heap_len=0;a.heap_max=ia;for(n=0;n<f;n++)0!==B[2*n]?(a.heap[++a.heap_len]=C=n,a.depth[n]=0):B[2*n+1]=0;for(;2>a.heap_len;)t=a.heap[++a.heap_len]=2>C?++C:0,B[2*t]=1,a.depth[t]=0,a.opt_len--,d&&(a.static_len-=d[2*t+1]);b.max_code=C;for(n=Math.floor(a.heap_len/2);1<=n;n--)a.pqdownheap(B,n);t=f;do n=a.heap[1],a.heap[1]=a.heap[a.heap_len--],a.pqdownheap(B,1),d=a.heap[1],
a.heap[--a.heap_max]=n,a.heap[--a.heap_max]=d,B[2*t]=B[2*n]+B[2*d],a.depth[t]=Math.max(a.depth[n],a.depth[d])+1,B[2*n+1]=B[2*d+1]=t,a.heap[1]=t++,a.pqdownheap(B,1);while(2<=a.heap_len);a.heap[--a.heap_max]=a.heap[1];n=b.dyn_tree;for(var C=b.stat_desc.static_tree,p=b.stat_desc.extra_bits,k=b.stat_desc.extra_base,u=b.stat_desc.max_length,y,J,x=0,f=0;f<=Y;f++)a.bl_count[f]=0;n[2*a.heap[a.heap_max]+1]=0;for(t=a.heap_max+1;t<ia;t++)d=a.heap[t],f=n[2*n[2*d+1]+1]+1,f>u&&(f=u,x++),n[2*d+1]=f,d>b.max_code||
(a.bl_count[f]++,y=0,d>=k&&(y=p[d-k]),J=n[2*d],a.opt_len+=J*(f+y),C&&(a.static_len+=J*(C[2*d+1]+y)));if(0!==x){do{for(f=u-1;0===a.bl_count[f];)f--;a.bl_count[f]--;a.bl_count[f+1]+=2;a.bl_count[u]--;x-=2}while(0<x);for(f=u;0!==f;f--)for(d=a.bl_count[f];0!==d;)C=a.heap[--t],C>b.max_code||(n[2*C+1]!=f&&(a.opt_len+=(f-n[2*C+1])*n[2*C],n[2*C+1]=f),d--)}n=b.max_code;t=a.bl_count;a=[];d=0;for(f=1;f<=Y;f++)a[f]=d=d+t[f-1]<<1;for(t=0;t<=n;t++)if(p=B[2*t+1],0!==p){d=B;f=2*t;C=a[p]++;k=0;do k|=C&1,C>>>=1,k<<=
1;while(0<--p);d[f]=k>>>1}}}function u(b,a,k,d,f){this.static_tree=b;this.extra_bits=a;this.extra_base=k;this.elems=d;this.max_length=f}function F(b,a,k,d,f){this.good_length=b;this.max_lazy=a;this.nice_length=k;this.max_chain=d;this.func=f}function Xa(b,a,k,d){var f=b[2*a];b=b[2*k];return f<b||f==b&&d[a]<=d[k]}function eb(){function b(){var a;for(a=0;a<Fa;a++)U[2*a]=0;for(a=0;a<Ga;a++)X[2*a]=0;for(a=0;a<Ha;a++)G[2*a]=0;U[2*ka]=1;N=Ia=m.opt_len=m.static_len=0}function a(a,l){var c,g=-1,w,f=a[1],b=
0,e=7,d=4;0===f&&(e=138,d=3);a[2*(l+1)+1]=65535;for(c=0;c<=l;c++)w=f,f=a[2*(c+1)+1],++b<e&&w==f||(b<d?G[2*w]+=b:0!==w?(w!=g&&G[2*w]++,G[2*Ya]++):10>=b?G[2*Za]++:G[2*$a]++,b=0,g=w,0===f?(e=138,d=3):w==f?(e=6,d=3):(e=7,d=4))}function B(a){m.pending_buf[m.pending++]=a}function d(a){B(a&255);B(a>>>8&255)}function f(a,l){D>Ja-l?(I|=a<<D&65535,d(I),I=a>>>Ja-D,D+=l-Ja):(I|=a<<D&65535,D+=l)}function n(a,l){var c=2*a;f(l[c]&65535,l[c+1]&65535)}function C(a,l){var c,g=-1,w,b=a[1],e=0,d=7,h=4;0===b&&(d=138,
h=3);for(c=0;c<=l;c++)if(w=b,b=a[2*(c+1)+1],!(++e<d&&w==b)){if(e<h){do n(w,G);while(0!==--e)}else 0!==w?(w!=g&&(n(w,G),e--),n(Ya,G),f(e-3,2)):10>=e?(n(Za,G),f(e-3,3)):(n($a,G),f(e-11,7));e=0;g=w;0===b?(d=138,h=3):w==b?(d=6,h=3):(d=7,h=4)}}function t(){16==D?(d(I),D=I=0):8<=D&&(B(I&255),I>>>=8,D-=8)}function ja(a,l){var c,g,b;m.pending_buf[la+2*N]=a>>>8&255;m.pending_buf[la+2*N+1]=a&255;m.pending_buf[Ka+N]=l&255;N++;0===a?U[2*l]++:(Ia++,a--,U[2*(p._length_code[l]+ta+1)]++,X[2*p.d_code(a)]++);if(0===
(N&8191)&&2<H){c=8*N;g=e-O;for(b=0;b<Ga;b++)c+=X[2*b]*(5+p.extra_dbits[b]);if(Ia<Math.floor(N/2)&&c>>>3<Math.floor(g/2))return!0}return N==ba-1}function F(a,l){var c,g,b=0,e,d;if(0!==N){do c=m.pending_buf[la+2*b]<<8&65280|m.pending_buf[la+2*b+1]&255,g=m.pending_buf[Ka+b]&255,b++,0===c?n(g,a):(e=p._length_code[g],n(e+ta+1,a),d=p.extra_lbits[e],0!==d&&(g-=p.base_length[e],f(g,d)),c--,e=p.d_code(c),n(e,l),d=p.extra_dbits[e],0!==d&&(c-=p.base_dist[e],f(c,d)));while(b<N)}n(ka,a);ma=a[2*ka+1]}function Va(){8<
D?d(I):0<D&&B(I&255);D=I=0}function Wa(a,l,c){f((fb<<1)+(c?1:0),3);Va();ma=8;d(l);d(~l);m.pending_buf.set(h.subarray(a,a+l),m.pending);m.pending+=l}function J(d){var l=0<=O?O:-1,c=e-O,g,w,h=0;if(0<H){na.build_tree(m);oa.build_tree(m);a(U,na.max_code);a(X,oa.max_code);La.build_tree(m);for(h=Ha-1;3<=h&&0===G[2*p.bl_order[h]+1];h--);m.opt_len+=3*(h+1)+14;g=m.opt_len+3+7>>>3;w=m.static_len+3+7>>>3;w<=g&&(g=w)}else g=w=c+5;if(c+4<=g&&-1!=l)Wa(l,c,d);else if(w==g)f((Ma<<1)+(d?1:0),3),F(u.static_ltree,u.static_dtree);
else{f((gb<<1)+(d?1:0),3);l=na.max_code+1;c=oa.max_code+1;h+=1;f(l-257,5);f(c-1,5);f(h-4,4);for(g=0;g<h;g++)f(G[2*p.bl_order[g]+1],3);C(U,l-1);C(X,c-1);F(U,X)}b();d&&Va();O=e;z.flush_pending()}function T(){var a,l,c,g;do{g=sa-r-e;if(0===g&&0===e&&0===r)g=v;else if(-1==g)g--;else if(e>=v+v-x){h.set(h.subarray(v,v+v),0);ca-=v;e-=v;O-=v;c=a=da;do l=A[--c]&65535,A[c]=l>=v?l-v:0;while(0!==--a);c=a=v;do l=S[--c]&65535,S[c]=l>=v?l-v:0;while(0!==--a);g+=v}if(0===z.avail_in)break;a=z.read_buf(h,e+r,g);r+=
a;r>=k&&(q=h[e]&255,q=(q<<V^h[e+1]&255)&W)}while(r<x&&0!==z.avail_in)}function Y(a){var l=65535,c;for(l>Na-5&&(l=Na-5);;){if(1>=r){T();if(0===r&&a==ea)return K;if(0===r)break}e+=r;r=0;c=O+l;if(0===e||e>=c)if(r=e-c,e=c,J(!1),0===z.avail_out)return K;if(e-O>=v-x&&(J(!1),0===z.avail_out))return K}J(a==y);return 0===z.avail_out?a==y?pa:K:a==y?ua:va}function ia(a){var l=Oa,c=e,g,b=L,d=e>v-x?e-(v-x):0,f=Pa,n=Z,m=e+wa,k=h[c+b-1],q=h[c+b];L>=Qa&&(l>>=2);f>r&&(f=r);do if(g=a,h[g+b]==q&&h[g+b-1]==k&&h[g]==
h[c]&&h[++g]==h[c+1]){c+=2;for(g++;h[++c]==h[++g]&&h[++c]==h[++g]&&h[++c]==h[++g]&&h[++c]==h[++g]&&h[++c]==h[++g]&&h[++c]==h[++g]&&h[++c]==h[++g]&&h[++c]==h[++g]&&c<m;);g=wa-(m-c);c=m-wa;if(g>b){ca=a;b=g;if(g>=f)break;k=h[c+b-1];q=h[c+b]}}while((a=S[a&n]&65535)>d&&0!==--l);return b<=r?b:r}function Ea(a){for(var b=0,c,g;;){if(r<x){T();if(r<x&&a==ea)return K;if(0===r)break}r>=k&&(q=(q<<V^h[e+(k-1)]&255)&W,b=A[q]&65535,S[e&Z]=A[q],A[q]=e);L=E;ab=ca;E=k-1;0!==b&&L<xa&&(e-b&65535)<=v-x&&(qa!=ya&&(E=ia(b)),
5>=E&&(qa==hb||E==k&&4096<e-ca)&&(E=k-1));if(L>=k&&E<=L){g=e+r-k;c=ja(e-1-ab,L-k);r-=L-1;L-=2;do++e<=g&&(q=(q<<V^h[e+(k-1)]&255)&W,b=A[q]&65535,S[e&Z]=A[q],A[q]=e);while(0!==--L);fa=0;E=k-1;e++;if(c&&(J(!1),0===z.avail_out))return K}else if(0!==fa){if(ja(0,h[e-1]&255)&&J(!1),e++,r--,0===z.avail_out)return K}else fa=1,e++,r--}0!==fa&&(ja(0,h[e-1]&255),fa=0);J(a==y);return 0===z.avail_out?a==y?pa:K:a==y?ua:va}var m=this,z,M,Na,ga,v,Ra,Z,h,sa,S,A,q,da,Sa,W,V,O,E,ab,fa,e,ca,r,L,Oa,xa,H,qa,Qa,Pa,U,X,G,
na=new p,oa=new p,La=new p;m.depth=[];var Ka,ba,N,la,Ia,ma,I,D;m.bl_count=[];m.heap=[];U=[];X=[];G=[];m.pqdownheap=function(a,b){for(var c=m.heap,g=c[b],e=b<<1;e<=m.heap_len;){e<m.heap_len&&Xa(a,c[e+1],c[e],m.depth)&&e++;if(Xa(a,g,c[e],m.depth))break;c[b]=c[e];b=e;e<<=1}c[b]=g};m.deflateInit=function(a,l,c,g,d,f){g||(g=Ta);d||(d=ib);f||(f=jb);a.msg=null;l==za&&(l=6);if(1>d||d>kb||g!=Ta||9>c||15<c||0>l||9<l||0>f||f>ya)return P;a.dstate=m;Ra=c;v=1<<Ra;Z=v-1;Sa=d+7;da=1<<Sa;W=da-1;V=Math.floor((Sa+k-
1)/k);h=new Uint8Array(2*v);S=[];A=[];ba=1<<d+6;m.pending_buf=new Uint8Array(4*ba);Na=4*ba;la=Math.floor(ba/2);Ka=3*ba;H=l;qa=f;a.total_in=a.total_out=0;a.msg=null;m.pending=0;m.pending_out=0;M=Aa;ga=ea;na.dyn_tree=U;na.stat_desc=u.static_l_desc;oa.dyn_tree=X;oa.stat_desc=u.static_d_desc;La.dyn_tree=G;La.stat_desc=u.static_bl_desc;D=I=0;ma=8;b();sa=2*v;for(a=A[da-1]=0;a<da-1;a++)A[a]=0;xa=Q[H].max_lazy;Qa=Q[H].good_length;Pa=Q[H].nice_length;Oa=Q[H].max_chain;r=O=e=0;E=L=k-1;q=fa=0;return R};m.deflateEnd=
function(){if(M!=Ua&&M!=Aa&&M!=ra)return P;h=S=A=m.pending_buf=null;m.dstate=null;return M==Aa?lb:R};m.deflateParams=function(a,b,c){var e=R;b==za&&(b=6);if(0>b||9<b||0>c||c>ya)return P;Q[H].func!=Q[b].func&&0!==a.total_in&&(e=a.deflate(bb));H!=b&&(H=b,xa=Q[H].max_lazy,Qa=Q[H].good_length,Pa=Q[H].nice_length,Oa=Q[H].max_chain);qa=c;return e};m.deflateSetDictionary=function(a,b,c){a=c;var d=0;if(!b||M!=Ua)return P;if(a<k)return R;a>v-x&&(a=v-x,d=c-a);h.set(b.subarray(d,d+a),0);O=e=a;q=h[0]&255;q=(q<<
V^h[1]&255)&W;for(b=0;b<=a-k;b++)q=(q<<V^h[b+(k-1)]&255)&W,S[b&Z]=A[q],A[q]=b;return R};m.deflate=function(a,b){var c,d,p;if(b>y||0>b)return P;if(!a.next_out||!a.next_in&&0!==a.avail_in||M==ra&&b!=y)return a.msg=Ba[Ca-P],P;if(0===a.avail_out)return a.msg=Ba[Ca-ha],ha;z=a;c=ga;ga=b;M==Ua&&(d=Ta+(Ra-8<<4)<<8,p=(H-1&255)>>1,3<p&&(p=3),d|=p<<6,0!==e&&(d|=mb),M=Aa,d+=31-d%31,B(d>>8&255),B(d&255));if(0!==m.pending){if(z.flush_pending(),0===z.avail_out)return ga=-1,R}else if(0===z.avail_in&&b<=c&&b!=y)return z.msg=
Ba[Ca-ha],ha;if(M==ra&&0!==z.avail_in)return a.msg=Ba[Ca-ha],ha;if(0!==z.avail_in||0!==r||b!=ea&&M!=ra){c=-1;switch(Q[H].func){case cb:c=Y(b);break;case Da:a:{for(c=0;;){if(r<x){T();if(r<x&&b==ea){c=K;break a}if(0===r)break}r>=k&&(q=(q<<V^h[e+(k-1)]&255)&W,c=A[q]&65535,S[e&Z]=A[q],A[q]=e);0!==c&&(e-c&65535)<=v-x&&qa!=ya&&(E=ia(c));if(E>=k)if(d=ja(e-ca,E-k),r-=E,E<=xa&&r>=k){E--;do e++,q=(q<<V^h[e+(k-1)]&255)&W,c=A[q]&65535,S[e&Z]=A[q],A[q]=e;while(0!==--E);e++}else e+=E,E=0,q=h[e]&255,q=(q<<V^h[e+
1]&255)&W;else d=ja(0,h[e]&255),r--,e++;if(d&&(J(!1),0===z.avail_out)){c=K;break a}}J(b==y);c=0===z.avail_out?b==y?pa:K:b==y?ua:va}break;case aa:c=Ea(b)}if(c==pa||c==ua)M=ra;if(c==K||c==pa)return 0===z.avail_out&&(ga=-1),R;if(c==va){if(b==bb)f(Ma<<1,3),n(ka,u.static_ltree),t(),9>1+ma+10-D&&(f(Ma<<1,3),n(ka,u.static_ltree),t()),ma=7;else if(Wa(0,0,!1),b==nb)for(c=0;c<da;c++)A[c]=0;z.flush_pending();if(0===z.avail_out)return ga=-1,R}}return b!=y?R:db}}function Ea(){this.total_out=this.avail_out=this.total_in=
this.avail_in=this.next_out_index=this.next_in_index=0}var Y=15,Ga=30,Ha=19,ta=256,Fa=ta+1+29,ia=2*Fa+1,ka=256,Ya=16,Za=17,$a=18,Ja=16,za=-1,hb=1,ya=2,jb=0,ea=0,bb=1,nb=3,y=4,R=0,db=1,Ca=2,P=-2,lb=-3,ha=-5,sa=[0,1,2,3,4,4,5,5,6,6,6,6,7,7,7,7,8,8,8,8,8,8,8,8,9,9,9,9,9,9,9,9,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,13,13,13,13,13,13,13,13,13,13,13,13,
13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,15,0,0,16,17,18,18,19,19,20,20,20,20,21,21,21,21,22,22,22,22,
22,22,22,22,23,23,23,23,23,23,23,23,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,28,
28,28,28,28,28,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29,29];p._length_code=[0,1,2,3,4,5,6,7,8,8,9,9,10,10,11,11,12,12,12,12,13,13,13,13,14,14,14,14,15,15,15,15,16,16,16,16,16,16,16,16,17,17,17,17,17,17,17,17,18,18,18,18,18,18,18,18,19,19,19,19,19,19,19,19,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,22,
22,22,22,22,22,22,22,22,22,22,22,22,22,22,22,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,23,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,25,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,26,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,27,28];p.base_length=[0,1,2,3,
4,5,6,7,8,10,12,14,16,20,24,28,32,40,48,56,64,80,96,112,128,160,192,224,0];p.base_dist=[0,1,2,3,4,6,8,12,16,24,32,48,64,96,128,192,256,384,512,768,1024,1536,2048,3072,4096,6144,8192,12288,16384,24576];p.d_code=function(b){return 256>b?sa[b]:sa[256+(b>>>7)]};p.extra_lbits=[0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,3,3,3,3,4,4,4,4,5,5,5,5,0];p.extra_dbits=[0,0,0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,10,10,11,11,12,12,13,13];p.extra_blbits=[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,3,7];p.bl_order=[16,17,18,0,8,7,9,6,
10,5,11,4,12,3,13,2,14,1,15];u.static_ltree=[12,8,140,8,76,8,204,8,44,8,172,8,108,8,236,8,28,8,156,8,92,8,220,8,60,8,188,8,124,8,252,8,2,8,130,8,66,8,194,8,34,8,162,8,98,8,226,8,18,8,146,8,82,8,210,8,50,8,178,8,114,8,242,8,10,8,138,8,74,8,202,8,42,8,170,8,106,8,234,8,26,8,154,8,90,8,218,8,58,8,186,8,122,8,250,8,6,8,134,8,70,8,198,8,38,8,166,8,102,8,230,8,22,8,150,8,86,8,214,8,54,8,182,8,118,8,246,8,14,8,142,8,78,8,206,8,46,8,174,8,110,8,238,8,30,8,158,8,94,8,222,8,62,8,190,8,126,8,254,8,1,8,129,8,
65,8,193,8,33,8,161,8,97,8,225,8,17,8,145,8,81,8,209,8,49,8,177,8,113,8,241,8,9,8,137,8,73,8,201,8,41,8,169,8,105,8,233,8,25,8,153,8,89,8,217,8,57,8,185,8,121,8,249,8,5,8,133,8,69,8,197,8,37,8,165,8,101,8,229,8,21,8,149,8,85,8,213,8,53,8,181,8,117,8,245,8,13,8,141,8,77,8,205,8,45,8,173,8,109,8,237,8,29,8,157,8,93,8,221,8,61,8,189,8,125,8,253,8,19,9,275,9,147,9,403,9,83,9,339,9,211,9,467,9,51,9,307,9,179,9,435,9,115,9,371,9,243,9,499,9,11,9,267,9,139,9,395,9,75,9,331,9,203,9,459,9,43,9,299,9,171,9,
427,9,107,9,363,9,235,9,491,9,27,9,283,9,155,9,411,9,91,9,347,9,219,9,475,9,59,9,315,9,187,9,443,9,123,9,379,9,251,9,507,9,7,9,263,9,135,9,391,9,71,9,327,9,199,9,455,9,39,9,295,9,167,9,423,9,103,9,359,9,231,9,487,9,23,9,279,9,151,9,407,9,87,9,343,9,215,9,471,9,55,9,311,9,183,9,439,9,119,9,375,9,247,9,503,9,15,9,271,9,143,9,399,9,79,9,335,9,207,9,463,9,47,9,303,9,175,9,431,9,111,9,367,9,239,9,495,9,31,9,287,9,159,9,415,9,95,9,351,9,223,9,479,9,63,9,319,9,191,9,447,9,127,9,383,9,255,9,511,9,0,7,64,
7,32,7,96,7,16,7,80,7,48,7,112,7,8,7,72,7,40,7,104,7,24,7,88,7,56,7,120,7,4,7,68,7,36,7,100,7,20,7,84,7,52,7,116,7,3,8,131,8,67,8,195,8,35,8,163,8,99,8,227,8];u.static_dtree=[0,5,16,5,8,5,24,5,4,5,20,5,12,5,28,5,2,5,18,5,10,5,26,5,6,5,22,5,14,5,30,5,1,5,17,5,9,5,25,5,5,5,21,5,13,5,29,5,3,5,19,5,11,5,27,5,7,5,23,5];u.static_l_desc=new u(u.static_ltree,p.extra_lbits,ta+1,Fa,Y);u.static_d_desc=new u(u.static_dtree,p.extra_dbits,0,Ga,Y);u.static_bl_desc=new u(null,p.extra_blbits,0,Ha,7);var kb=9,ib=8,
cb=0,Da=1,aa=2,Q=[new F(0,0,0,0,cb),new F(4,4,8,4,Da),new F(4,5,16,8,Da),new F(4,6,32,32,Da),new F(4,4,16,16,aa),new F(8,16,32,32,aa),new F(8,16,128,128,aa),new F(8,32,128,256,aa),new F(32,128,258,1024,aa),new F(32,258,258,4096,aa)],Ba="need dictionary;stream end;;;stream error;data error;;buffer error;;".split(";"),K=0,va=1,pa=2,ua=3,mb=32,Ua=42,Aa=113,ra=666,Ta=8,fb=0,Ma=1,gb=2,k=3,wa=258,x=wa+k+1;Ea.prototype={deflateInit:function(b,a){this.dstate=new eb;a||(a=Y);return this.dstate.deflateInit(this,
b,a)},deflate:function(b){return this.dstate?this.dstate.deflate(this,b):P},deflateEnd:function(){if(!this.dstate)return P;var b=this.dstate.deflateEnd();this.dstate=null;return b},deflateParams:function(b,a){return this.dstate?this.dstate.deflateParams(this,b,a):P},deflateSetDictionary:function(b,a){return this.dstate?this.dstate.deflateSetDictionary(this,b,a):P},read_buf:function(b,a,k){var d=this.avail_in;d>k&&(d=k);if(0===d)return 0;this.avail_in-=d;b.set(this.next_in.subarray(this.next_in_index,
this.next_in_index+d),a);this.next_in_index+=d;this.total_in+=d;return d},flush_pending:function(){var b=this.dstate.pending;b>this.avail_out&&(b=this.avail_out);0!==b&&(this.next_out.set(this.dstate.pending_buf.subarray(this.dstate.pending_out,this.dstate.pending_out+b),this.next_out_index),this.next_out_index+=b,this.dstate.pending_out+=b,this.total_out+=b,this.avail_out-=b,this.dstate.pending-=b,0===this.dstate.pending&&(this.dstate.pending_out=0))}};T=T.zip||T;T.Deflater=T._jzlib_Deflater=function(b){var a=
new Ea,k=ea,d=new Uint8Array(512);b=b?b.level:za;"undefined"==typeof b&&(b=za);a.deflateInit(b);a.next_out=d;this.append=function(b,n){var p,t=[],u=0,x=0,y=0,F;if(b.length){a.next_in_index=0;a.next_in=b;a.avail_in=b.length;do{a.next_out_index=0;a.avail_out=512;p=a.deflate(k);if(p!=R)throw Error("deflating: "+a.msg);a.next_out_index&&(512==a.next_out_index?t.push(new Uint8Array(d)):t.push(new Uint8Array(d.subarray(0,a.next_out_index))));y+=a.next_out_index;n&&0<a.next_in_index&&a.next_in_index!=u&&
(n(a.next_in_index),u=a.next_in_index)}while(0<a.avail_in||0===a.avail_out);F=new Uint8Array(y);t.forEach(function(a){F.set(a,x);x+=a.length});return F}};this.flush=function(){var b,k=[],p=0,t=0,u;do{a.next_out_index=0;a.avail_out=512;b=a.deflate(y);if(b!=db&&b!=R)throw Error("deflating: "+a.msg);0<512-a.avail_out&&k.push(new Uint8Array(d.subarray(0,a.next_out_index)));t+=a.next_out_index}while(0<a.avail_in||0===a.avail_out);a.deflateEnd();u=new Uint8Array(t);k.forEach(function(a){u.set(a,p);p+=a.length});
return u}}})(this);
