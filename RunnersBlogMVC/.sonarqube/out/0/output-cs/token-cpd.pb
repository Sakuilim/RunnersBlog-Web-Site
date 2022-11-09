ê
mC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Common\Extensions\DtoExtensions.cs
	namespace 	
RunnersBlogMVC
 
{ 
public 

static 
class 
DtoExtensions %
{ 
public 
static 
ItemDto 
AsDto #
(# $
this$ (
Item) -
item. 2
)2 3
{		 	
return

 
new

 
ItemDto

 
{ 
Name 
= 
item 
. 
Name  
,  !
Price 
= 
item 
. 
Price "
} 
; 
} 	
} 
} Ô!
kC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Controllers\AccountController.cs
	namespace 	
RunnersBlogMVC
 
. 
Controllers $
{ 
public		 

class		 
AccountController		 "
:		# $
BaseController		% 3
{

 
private 
UserManager 
< 
ApplicationUser +
>+ ,
_userManager- 9
;9 :
private 
SignInManager 
< 
ApplicationUser -
>- .
_signInManager/ =
;= >
public 
AccountController  
(  !
UserManager! ,
<, -
ApplicationUser- <
>< =
userManager> I
,I J
SignInManagerK X
<X Y
ApplicationUserY h
>h i
signInManagerj w
)w x
{ 	
this 
. 
_userManager 
= 
userManager  +
;+ ,
this 
. 
_signInManager 
=  !
signInManager" /
;/ 0
} 	
public 
IActionResult 
Login "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
public 
IActionResult 
AccessDenied )
() *
)* +
{ 	
return 
View 
( 
) 
; 
} 	
[ 	
HttpPost	 
] 
[ 	
AllowAnonymous	 
] 
[ 	$
ValidateAntiForgeryToken	 !
]! "
public   
async   
Task   
<   
ActionResult   &
>  & '
Login  ( -
(  - .
[  . /
Required  / 7
]  7 8
[  8 9
EmailAddress  9 E
]  E F
string  G M
email  N S
,  S T
[  U V
Required  V ^
]  ^ _
string  ` f
password  g o
)  o p
{!! 	
if"" 
("" 

ModelState"" 
."" 
IsValid"" "
)""" #
{## 
ApplicationUser$$ 
appUser$$  '
=$$( )
await$$* /
_userManager$$0 <
.$$< =
FindByEmailAsync$$= M
($$M N
email$$N S
)$$S T
;$$T U
if%% 
(%% 
appUser%% 
!=%% 
null%% #
)%%# $
{&& 
	Microsoft'' 
.'' 

AspNetCore'' (
.''( )
Identity'') 1
.''1 2
SignInResult''2 >
result''? E
=''F G
await''H M
_signInManager''N \
.''\ ]
PasswordSignInAsync''] p
(''p q
appUser''q x
,''x y
password	''z Ç
,
''Ç É
false
''Ñ â
,
''â ä
false
''ã ê
)
''ê ë
;
''ë í
if(( 
((( 
result(( 
.(( 
	Succeeded(( (
)((( )
{)) 
return** 
RedirectToAction** /
(**/ 0
$str**0 7
,**7 8
$str**9 ?
)**? @
;**@ A
}++ 
},, 

ModelState-- 
.-- 
AddModelError-- (
(--( )
nameof--) /
(--/ 0
email--0 5
)--5 6
,--6 7
$str--8 a
)--a b
;--b c
}// 
return00 
View00 
(00 
)00 
;00 
}11 	
[22 	
	Authorize22	 
]22 
public33 
async33 
Task33 
<33 
ActionResult33 &
>33& '
Logout33( .
(33. /
)33/ 0
{44 	
await55 
_signInManager55  
.55  !
SignOutAsync55! -
(55- .
)55. /
;55/ 0
return66 
RedirectToAction66 #
(66# $
$str66$ +
,66+ ,
$str66- 3
)663 4
;664 5
}77 	
}88 
}99 ˚
hC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Controllers\BaseController.cs
	namespace 	
RunnersBlogMVC
 
. 
Controllers $
{ 
public 

abstract 
class 
BaseController (
:) *

Controller+ 5
{ 
} 
} á
hC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Controllers\HomeController.cs
	namespace 	
RunnersBlogMVC
 
. 
Controllers $
{ 
public 

class 
HomeController 
:  !

Controller" ,
{ 
private		 
readonly		 
ILogger		  
<		  !
HomeController		! /
>		/ 0
_logger		1 8
;		8 9
public 
HomeController 
( 
ILogger %
<% &
HomeController& 4
>4 5
logger6 <
)< =
{ 	
_logger 
= 
logger 
; 
} 	
public 
IActionResult 
Index "
(" #
)# $
{ 	
return 
View 
( 
) 
; 
} 	
public 
IActionResult 
Privacy $
($ %
)% &
{ 	
return 
View 
( 
) 
; 
} 	
[ 	
ResponseCache	 
( 
Duration 
=  !
$num" #
,# $
Location% -
=. /!
ResponseCacheLocation0 E
.E F
NoneF J
,J K
NoStoreL S
=T U
trueV Z
)Z [
][ \
public 
IActionResult 
Error "
(" #
)# $
{ 	
return 
View 
( 
new 
ErrorViewModel *
{+ ,
	RequestId- 6
=7 8
Activity9 A
.A B
CurrentB I
?I J
.J K
IdK M
??N P
HttpContextQ \
.\ ]
TraceIdentifier] l
}m n
)n o
;o p
} 	
} 
}   ¥*
iC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Controllers\ItemsController.cs
	namespace 	
RunnersBlogMVC
 
. 
Controllers $
{		 
public 

class 
ItemsController  
:! "
BaseController# 1
{ 
private 
readonly 
IBaseService %
<% &
Item& *
,* +
ItemDto, 3
>3 4
itemService5 @
;@ A
private 
readonly 
CancellationToken *
cancellationToken+ <
;< =
public 
ItemsController 
( 
IBaseService +
<+ ,
Item, 0
,0 1
ItemDto2 9
>9 :
itemService; F
)F G
{ 	
this 
. 
itemService 
= 
itemService *
;* +
cancellationToken 
= 
new  #
CancellationToken$ 5
(5 6
)6 7
;7 8
} 	
[ 	
HttpGet	 
] 
[ 	
	Authorize	 
( 
Roles 
= 
$str "
)" #
]# $
public 
async 
Task 
< 
ActionResult &
<& '
Item' +
>+ ,
>, -
DeleteItemAsync. =
(= >
Guid> B
idC E
)E F
{ 	
return 
await 
itemService $
.$ %
DeleteMiddlePage% 5
(5 6
id6 8
,8 9
cancellationToken: K
)K L
;L M
} 	
public 
async 
Task 
< 
ActionResult &
<& '
Item' +
>+ ,
>, -
UpdateItemAsync. =
(= >
Guid> B
idC E
)E F
{ 	
return 
await 
itemService $
.$ %
UpdateMiddlePage% 5
(5 6
id6 8
,8 9
cancellationToken: K
)K L
;L M
} 	
[   	
HttpGet  	 
]   
[!! 	
	Authorize!!	 
(!! 
Roles!! 
=!! 
$str!! "
)!!" #
]!!# $
public"" 
ActionResult"" 

CreateItem"" &
(""& '
)""' (
{## 	
return$$ 
View$$ 
($$ 
)$$ 
;$$ 
}%% 	
['' 	
HttpGet''	 
]'' 
[(( 	
AllowAnonymous((	 
](( 
public)) 
async)) 
Task)) 
<)) 
ActionResult)) &
>))& '
GetAllItemsAsync))( 8
())8 9
)))9 :
{** 	
return++ 
await++ 
itemService++ $
.++$ %
GetAllAsync++% 0
(++0 1
cancellationToken++1 B
)++B C
;++C D
}-- 	
[// 	
HttpPost//	 
]// 
[00 	$
ValidateAntiForgeryToken00	 !
]00! "
[11 	
	Authorize11	 
(11 
Roles11 
=11 
$str11 "
)11" #
]11# $
public22 
async22 
Task22 
<22 
ActionResult22 &
>22& '
CreateItemAsync22( 7
(227 8
ItemDto228 ?
itemDto22@ G
)22G H
{33 	
return44 
await44 
itemService44 $
.44$ %
CreateAsync44% 0
(440 1
itemDto441 8
,448 9
cancellationToken44: K
)44K L
;44L M
}55 	
[77 	
HttpPost77	 
]77 
[88 	
	Authorize88	 
(88 
Roles88 
=88 
$str88 "
)88" #
]88# $
public99 
async99 
Task99 
<99 
ActionResult99 &
<99& '
Item99' +
>99+ ,
>99, -
UpdateByIdAsync99. =
(99= >
Guid99> B
id99C E
,99E F
ItemDto99G N
itemDto99O V
)99V W
{:: 	
return;; 
await;; 
itemService;; $
.;;$ %
UpdateByIdAsync;;% 4
(;;4 5
id;;5 7
,;;7 8
itemDto;;9 @
,;;@ A
cancellationToken;;B S
);;S T
;;;T U
}<< 	
[>> 	
HttpGet>>	 
]>> 
[?? 	
	Authorize??	 
(?? 
Roles?? 
=?? 
$str?? "
)??" #
]??# $
public@@ 
async@@ 
Task@@ 
<@@ 
ActionResult@@ &
<@@& '
Item@@' +
>@@+ ,
>@@, -
DeleteByIdAsync@@. =
(@@= >
Guid@@> B
id@@C E
)@@E F
{AA 	
returnBB 
awaitBB 
itemServiceBB $
.BB$ %
DeleteByIdAsyncBB% 4
(BB4 5
idBB5 7
,BB7 8
cancellationTokenBB9 J
)BBJ K
;BBK L
}CC 	
}DD 
}EE ˜
kC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Controllers\SecuredController.cs
	namespace 	
RunnersBlogMVC
 
. 
Controllers $
{ 
[ 
	Authorize 
] 
public 

class 
SecuredController "
:# $

Controller% /
{		 
[ 	
	Authorize	 
( 
Roles 
= 
$str "
)" #
]# $
public 
ActionResult 
Index !
(! "
)" #
{ 	
return 
View 
( 
) 
; 
} 	
} 
} Í>
hC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Controllers\UserController.cs
	namespace 	
RunnersBlogMVC
 
. 
Controllers $
{		 
public

 

class

 
UserController

 
:

  !

Controller

" ,
{ 
private 
UserManager 
< 
ApplicationUser +
>+ ,
userManager- 8
;8 9
private 
RoleManager 
< 
ApplicationRole +
>+ ,
roleManager- 8
;8 9
public 
UserController 
( 
UserManager )
<) *
ApplicationUser* 9
>9 :
userManager; F
,F G
RoleManagerH S
<S T
ApplicationRoleT c
>c d
roleManagere p
)p q
{ 	
this 
. 
userManager 
= 
userManager *
;* +
this 
. 
roleManager 
= 
roleManager *
;* +
} 	
public 
IActionResult 

CreateUser '
(' (
)( )
{ 	
return 
View 
( 
) 
; 
} 	
public 
IActionResult 

CreateRole '
(' (
)( )
{ 	
return 
View 
( 
) 
; 
} 	
[ 	
AllowAnonymous	 
] 
[ 	
HttpPost	 
] 
public 
async 
Task 
< 
IActionResult '
>' (

CreateUser) 3
(3 4
User4 8
user9 =
)= >
{ 	
if   
(   

ModelState   
.   
IsValid   "
)  " #
{!! 
ApplicationUser"" 
appUser""  '
=""( )
new""* -
(""- .
)"". /
{## 
UserName$$ 
=$$ 
user$$ #
.$$# $
Name$$$ (
,$$( )
Email%% 
=%% 
user%%  
.%%  !
Email%%! &
}&& 
;&& 
IdentityResult(( 
result(( %
=((& '
await((( -
userManager((. 9
.((9 :
CreateAsync((: E
(((E F
appUser((F M
,((M N
user((O S
.((S T
Password((T \
)((\ ]
;((] ^
appUser** 
.** 
SecurityStamp** %
=**& '
Guid**( ,
.**, -
NewGuid**- 4
(**4 5
)**5 6
.**6 7
ToString**7 ?
(**? @
)**@ A
;**A B
bool,, 
userRoleExists,, #
=,,$ %
await,,& +
roleManager,,, 7
.,,7 8
RoleExistsAsync,,8 G
(,,G H
$str,,H N
),,N O
;,,O P
if-- 
(-- 
!-- 
userRoleExists-- "
)--" #
{.. 
await// 
roleManager// %
.//% &
CreateAsync//& 1
(//1 2
new//2 5
ApplicationRole//6 E
(//E F
)//F G
{//H I
Name//J N
=//O P
$str//Q W
}//W X
)//X Y
;//Y Z
}00 
await22 
userManager22 !
.22! "
AddToRoleAsync22" 0
(220 1
appUser221 8
,228 9
UserRole229 A
.22A B
User22B F
.22F G
ToString22G O
(22O P
)22P Q
)22Q R
;22R S
if44 
(44 
result44 
.44 
	Succeeded44 $
)44$ %
{55 
ViewBag66 
.66 
Message66 #
=66$ %
$str66& A
;66A B
}77 
else88 
{99 
foreach:: 
(:: 
IdentityError:: *
error::+ 0
in::1 3
result::4 :
.::: ;
Errors::; A
)::A B
{;; 

ModelState<< "
.<<" #
AddModelError<<# 0
(<<0 1
$str<<1 3
,<<3 4
error<<5 :
.<<: ;
Description<<; F
)<<F G
;<<G H
}== 
}>> 
}?? 
else@@ 
{AA 

ModelStateBB 
.BB 
AddModelErrorBB (
(BB( )
$strBB) 0
,BB0 1
errorMessageBB1 =
:BB= >
$strBB? d
)BBd e
;BBe f
}CC 
returnDD 
ViewDD 
(DD 
userDD 
)DD 
;DD 
}EE 	
[GG 	
HttpPostGG	 
]GG 
[HH 	
	AuthorizeHH	 
(HH 
RolesHH 
=HH 
$strHH "
)HH" #
]HH# $
publicII 
asyncII 
TaskII 
<II 
IActionResultII '
>II' (

CreateRoleII) 3
(II3 4
[II4 5
RequiredII5 =
]II= >
[II> ?
EmailAddressII? K
]IIK L
stringIIM S
emailIIT Y
,IIY Z
UserRoleII[ c
userRoleIId l
)IIl m
{JJ 	
ifKK 
(KK 

ModelStateKK 
.KK 
IsValidKK "
)KK" #
{LL 
ApplicationUserMM 
existingAppUserMM  /
=MM0 1
awaitMM2 7
userManagerMM8 C
.MMC D
FindByEmailAsyncMMD T
(MMT U
emailMMU Z
)MMZ [
;MM[ \
ifNN 
(NN 
existingAppUserNN #
isNN$ &
notNN' *
nullNN+ /
)NN/ 0
{OO 
existingAppUserPP #
.PP# $
RolesPP$ )
.PP) *
ClearPP* /
(PP/ 0
)PP0 1
;PP1 2
boolRR 
userRoleExistsRR '
=RR( )
awaitRR* /
roleManagerRR0 ;
.RR; <
RoleExistsAsyncRR< K
(RRK L
userRoleRRL T
.RRT U
ToStringRRU ]
(RR] ^
)RR^ _
)RR_ `
;RR` a
ifSS 
(SS 
!SS 
userRoleExistsSS '
)SS' (
{TT 
awaitUU 
roleManagerUU )
.UU) *
CreateAsyncUU* 5
(UU5 6
newUU6 9
ApplicationRoleUU: I
(UUI J
)UUJ K
{UUL M
NameUUN R
=UUS T
userRoleUUU ]
.UU] ^
ToStringUU^ f
(UUf g
)UUg h
}UUi j
)UUj k
;UUk l
}VV 
varXX 
resultXX 
=XX  
awaitXX! &
userManagerXX' 2
.XX2 3
AddToRoleAsyncXX3 A
(XXA B
existingAppUserXXB Q
,XXQ R
userRoleXXS [
.XX[ \
ToStringXX\ d
(XXd e
)XXe f
)XXf g
;XXg h
ifZZ 
(ZZ 
resultZZ 
.ZZ 
	SucceededZZ (
)ZZ( )
{[[ 
ViewBag\\ 
.\\  
Message\\  '
=\\( )
result\\* 0
;\\0 1
}]] 
else^^ 
{__ 
foreach`` 
(``  !
IdentityError``! .
error``/ 4
in``5 7
result``8 >
.``> ?
Errors``? E
)``E F
{aa 

ModelStatebb &
.bb& '
AddModelErrorbb' 4
(bb4 5
$strbb5 7
,bb7 8
errorbb9 >
.bb> ?
Descriptionbb? J
)bbJ K
;bbK L
}cc 
}dd 
}ee 
}ff 
returngg 
Viewgg 
(gg 
)gg 
;gg 
}hh 	
}ii 
}kk ø
YC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\DTO\ItemDto.cs
	namespace 	
RunnersBlogMVC
 
. 
DTO 
{ 
public 

record 
ItemDto 
{ 
[ 	
Required	 
] 
public 
string 
Name 
{ 
get  
;  !
init" &
;& '
}( )
[		 	
Required			 
]		 
[

 	
Range

	 
(

 
$num

 
,

 
$num

 
)

 
]

 
public 
decimal 
Price 
{ 
get "
;" #
init$ (
;( )
}* +
} 
} è
uC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Models\ApplicationUsers\ApplicationRole.cs
	namespace 	
RunnersBlogMVC
 
. 
Models 
{ 
[ 
CollectionName 
( 
$str 
) 
] 
public 

class 
ApplicationRole  
:! "
MongoIdentityRole# 4
<4 5
Guid5 9
>9 :
{ 
}		 
}

 è
uC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Models\ApplicationUsers\ApplicationUser.cs
	namespace 	
RunnersBlogMVC
 
. 
Models 
{ 
[ 
CollectionName 
( 
$str 
) 
] 
public 

class 
ApplicationUser  
:! "
MongoIdentityUser# 4
<4 5
Guid5 9
>9 :
{ 
}		 
}

 ¬
cC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Models\ErrorViewModel.cs
	namespace 	
RunnersBlogMVC
 
. 
Models 
{ 
public 

class 
ErrorViewModel 
{ 
public 
string 
? 
	RequestId  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
bool 
ShowRequestId !
=>" $
!% &
string& ,
., -
IsNullOrEmpty- :
(: ;
	RequestId; D
)D E
;E F
} 
}		 ò
_C:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Models\Items\Item.cs
	namespace 	
RunnersBlogMVC
 
. 
Models 
{ 
public 

record 
Item 
{ 
public 
Guid 
Id 
{ 
get 
; 
init "
;" #
}$ %
public 
string 
Name 
{ 
get  
;  !
init" &
;& '
}( )
public 
decimal 
Price 
{ 
get "
;" #
init$ (
;( )
}* +
public 
DateTimeOffset 
CreatedDate )
{* +
get, /
;/ 0
init1 5
;5 6
}7 8
}		 
} Æ
_C:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Models\Users\User.cs
	namespace 	
RunnersBlogMVC
 
. 
Models 
{ 
public 

class 
User 
{ 
[ 	
EmailAddress	 
] 
[		 	
Required			 
(		 
ErrorMessage		 
=		  
$str		! =
)		= >
]		> ?
public

 
string

 
Email

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
[ 	
Required	 
( 
ErrorMessage 
=  
$str! <
)< =
]= >
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
[ 	
Required	 
( 
ErrorMessage 
=  
$str! @
)@ A
]A B
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
EnumDataType	 
( 
typeof 
( 
UserRole %
)% &
)& '
]' (
public 
string 
Role 
{ 
get  
;  !
set" %
;% &
}' (
=) *
UserRole+ 3
.3 4
User4 8
.8 9
ToString9 A
(A B
)B C
;C D
} 
public 

enum 
UserRole 
{ 
Admin 
, 
User 
} 
} ≥%
UC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
BsonSerializer 
. 
RegisterSerializer !
(! "
new" %
GuidSerializer& 4
(4 5
BsonType5 =
.= >
String> D
)D E
)E F
;F G
BsonSerializer 
. 
RegisterSerializer !
(! "
new" %$
DateTimeOffsetSerializer& >
(> ?
BsonType? G
.G H
StringH N
)N O
)O P
;P Q
ConfigurationManager 
configuration "
=# $
builder% ,
., -
Configuration- :
;: ;
builder 
. 
Services 
. #
AddControllersWithViews (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
builder 
. 
Services 
. 
AddSingleton 
< 
IItemsRepository .
,. /
MongoDbItemsRepo/ ?
>? @
(@ A
)A B
;B C
builder 
. 
Services 
. 
AddSingleton 
< 
IBaseService *
<* +
Item+ /
,/ 0
ItemDto1 8
>8 9
,9 :
ItemsService; G
>G H
(H I
)I J
;J K
var 
settings 
= 
configuration 
. 

GetSection '
(' (
nameof( .
(. /
MongoDbSettings/ >
)> ?
)? @
.@ A
GetA D
<D E
MongoDbSettingsE T
>T U
(U V
)V W
;W X
builder 
. 
Services 
. 
AddSingleton 
< 
IMongoClient *
>* +
(+ ,
serviceProvider, ;
=>< >
{ 
return 

new 
MongoClient 
( 
settings #
.# $
ConnectionString$ 4
)4 5
;5 6
} 
) 
; 
builder 
. 
Services 
. 
AddIdentity 
< 
ApplicationUser  
,  !
ApplicationRole" 1
>1 2
(2 3
)3 4
.   
AddMongoDbStores   
<   
ApplicationUser   %
,  % &
ApplicationRole  ' 6
,  6 7
Guid  8 <
>  < =
(  = >
settings!! 
.!! 
ConnectionString!! 
,!! 
$str!! &
)"" 
;"" 
var$$ 
app$$ 
=$$ 	
builder$$
 
.$$ 
Build$$ 
($$ 
)$$ 
;$$ 
if'' 
('' 
!'' 
app'' 
.'' 	
Environment''	 
.'' 
IsDevelopment'' "
(''" #
)''# $
)''$ %
{(( 
app)) 
.)) 
UseExceptionHandler)) 
()) 
$str)) )
)))) *
;))* +
app++ 
.++ 
UseHsts++ 
(++ 
)++ 
;++ 
},, 
app.. 
... 
UseHttpsRedirection.. 
(.. 
).. 
;.. 
app// 
.// 
UseStaticFiles// 
(// 
)// 
;// 
app11 
.11 

UseRouting11 
(11 
)11 
;11 
app33 
.33 
UseAuthentication33 
(33 
)33 
;33 
app44 
.44 
UseAuthorization44 
(44 
)44 
;44 
app66 
.66 

UseSwagger66 
(66 
)66 
;66 
app77 
.77 
UseSwaggerUI77 
(77 
)77 
;77 
app:: 
.:: 
MapControllerRoute:: 
(:: 
name;; 
:;; 	
$str;;
 
,;; 
pattern<< 
:<< 
$str<< 5
)<<5 6
;<<6 7
app>> 
.>> 
Run>> 
(>> 
)>> 	
;>>	 
§
kC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Repositories\IItemsRepository.cs
	namespace 	
RunnersBlogMVC
 
. 
Repositories %
{ 
public 

	interface 
IItemsRepository %
{ 
Task 
< 
Item 
> 
GetItemAsync 
(  
Guid  $
Id% '
,' (
CancellationToken) :
cancellationToken; L
)L M
;M N
Task 
< 
IEnumerable 
< 
Item 
> 
> 
GetItemsAsync  -
(- .
CancellationToken. ?
cancellationToken@ Q
)Q R
;R S
Task		 
CreateItemAsync		 
(		 
Item		 !
item		" &
,		& '
CancellationToken		( 9
cancellationToken		: K
)		K L
;		L M
Task

 
UpdateItemAsync

 
(

 
Item

 !
item

" &
,

& '
CancellationToken

( 9
cancellationToken

: K
)

K L
;

L M
Task 
DeleteItemAsync 
( 
Guid !
Id" $
,$ %
CancellationToken& 7
cancellationToken8 I
)I J
;J K
} 
} ™(
kC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Repositories\MongoDbItemsRepo.cs
	namespace 	
RunnersBlogMVC
 
. 
Repositories %
{ 
public 

class 
MongoDbItemsRepo !
:" #
IItemsRepository$ 4
{ 
private		 
const		 
string		 
databaseName		 )
=		* +
$str		, 5
;		5 6
private

 
const

 
string

 
collectionName

 +
=

, -
$str

. 5
;

5 6
private 
readonly 
IMongoCollection )
<) *
Item* .
>. /
itemsCollection0 ?
;? @
private 
readonly #
FilterDefinitionBuilder 0
<0 1
Item1 5
>5 6
filterBuilder7 D
=E F
BuildersG O
<O P
ItemP T
>T U
.U V
FilterV \
;\ ]
public 
MongoDbItemsRepo 
(  
IMongoClient  ,
mongoClient- 8
)8 9
{ 	
IMongoDatabase 
database #
=$ %
mongoClient& 1
.1 2
GetDatabase2 =
(= >
databaseName> J
)J K
;K L
itemsCollection 
= 
database &
.& '
GetCollection' 4
<4 5
Item5 9
>9 :
(: ;
collectionName; I
)I J
;J K
} 	
[ 	
Obsolete	 
] 
public 
async 
Task 
CreateItemAsync )
() *
Item* .
item/ 3
,3 4
CancellationToken5 F
cancellationTokenG X
)X Y
{ 	
await 
itemsCollection !
.! "
InsertOneAsync" 0
(0 1
item1 5
,5 6
cancellationToken7 H
)H I
;I J
} 	
public 
async 
Task 
DeleteItemAsync )
() *
Guid* .
Id/ 1
,1 2
CancellationToken3 D
cancellationTokenE V
)V W
{ 	
var 
filter 
= 
filterBuilder &
.& '
Eq' )
() *
item* .
=>/ 1
item2 6
.6 7
Id7 9
,9 :
Id; =
)= >
;> ?
await 
itemsCollection !
.! "
DeleteOneAsync" 0
(0 1
filter1 7
,7 8
cancellationToken9 J
)J K
;K L
} 	
public 
async 
Task 
< 
Item 
> 
GetItemAsync  ,
(, -
Guid- 1
Id2 4
,4 5
CancellationToken6 G
cancellationTokenH Y
)Y Z
{ 	
var 
filter 
= 
filterBuilder &
.& '
Eq' )
() *
item* .
=>/ 1
item2 6
.6 7
Id7 9
,9 :
Id; =
)= >
;> ?
return   
await   
itemsCollection   (
.  ( )
Find  ) -
(  - .
filter  . 4
)  4 5
.  5 6 
SingleOrDefaultAsync  6 J
(  J K
cancellationToken  K \
)  \ ]
;  ] ^
}!! 	
public"" 
async"" 
Task"" 
<"" 
IEnumerable"" %
<""% &
Item""& *
>""* +
>""+ ,
GetItemsAsync""- :
("": ;
CancellationToken""; L
cancellationToken""M ^
)""^ _
{## 	
return$$ 
await$$ 
itemsCollection$$ (
.$$( )
Find$$) -
($$- .
new$$. 1
BsonDocument$$2 >
($$> ?
)$$? @
)$$@ A
.$$A B
ToListAsync$$B M
($$M N
cancellationToken$$N _
)$$_ `
;$$` a
}%% 	
public&& 
async&& 
Task&& 
UpdateItemAsync&& )
(&&) *
Item&&* .
item&&/ 3
,&&3 4
CancellationToken&&5 F
cancellation&&G S
)&&S T
{'' 	
var(( 
filter(( 
=(( 
filterBuilder(( &
.((& '
Eq((' )
((() *
existingItem((* 6
=>((7 9
existingItem((: F
.((F G
Id((G I
,((I J
item((K O
.((O P
Id((P R
)((R S
;((S T
await)) 
itemsCollection)) !
.))! "
ReplaceOneAsync))" 1
())1 2
filter))2 8
,))8 9
item)): >
)))> ?
;))? @
}** 	
}++ 
},, √
cC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Services\IBaseService.cs
	namespace 	
RunnersBlogMVC
 
. 
Services !
{ 
public 

	interface 
IBaseService !
<! "
T" #
,# $
TDto$ (
>( )
where* /
T0 1
:2 3
class4 9
{ 
Task 
< 
ActionResult 
> 
GetAllAsync &
(& '
CancellationToken' 8
cancellationToken9 J
)J K
;K L
Task		 
<		 
ActionResult		 
<		 
T		 
>		 
>		 
GetByIdAsync		 *
(		* +
Guid		+ /
id		0 2
,		2 3
CancellationToken

 
cancellationToken

 /
)

/ 0
;

0 1
Task 
< 
ActionResult 
> 
CreateAsync &
(& '
TDto' +
dataDto, 3
,3 4
CancellationToken 
cancellationToken /
)/ 0
;0 1
Task 
< 
ActionResult 
< 
T 
> 
> 
DeleteByIdAsync -
(- .
Guid. 2
id3 5
,5 6
CancellationToken 
cancellationToken /
)/ 0
;0 1
Task 
< 
ActionResult 
> 
UpdateByIdAsync *
(* +
Guid+ /
id0 2
,2 3
TDto4 8
dataToUpdateWith9 I
,I J
CancellationToken 
cancellationToken /
)/ 0
;0 1
Task 
< 
ActionResult 
> 
DeleteMiddlePage +
(+ ,
Guid, 0
id1 3
,3 4
CancellationToken 
cancellationToken /
)/ 0
;0 1
Task 
< 
ActionResult 
> 
UpdateMiddlePage +
(+ ,
Guid, 0
id1 3
,3 4
CancellationToken 
cancellationToken .
). /
;/ 0
} 
} æA
cC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Services\ItemsService.cs
	namespace 	
RunnersBlogMVC
 
. 
Services !
{ 
public		 

class		 
ItemsService		 
:		 

Controller		  *
,		* +
IBaseService		, 8
<		8 9
Item		9 =
,		= >
ItemDto		> E
>		E F
{

 
private 
readonly 
IItemsRepository )
repo* .
;. /
public 
ItemsService 
( 
IItemsRepository ,
repo- 1
)1 2
{ 	
this 
. 
repo 
= 
repo 
; 
} 	
public 
async 
Task 
< 
ActionResult &
>& '
CreateAsync( 3
(3 4
ItemDto4 ;
itemDto< C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 	
Item 
item 
= 
new 
( 
) 
{ 
Id 
= 
Guid 
. 
NewGuid !
(! "
)" #
,# $
Name 
= 
itemDto 
. 
Name #
,# $
Price 
= 
itemDto 
.  
Price  %
,% &
CreatedDate 
= 
DateTimeOffset ,
., -
UtcNow- 3
,3 4
} 
; 
await 
repo 
. 
CreateItemAsync &
(& '
item' +
,+ ,
cancellationToken- >
)> ?
;? @
return 
RedirectToAction #
(# $
$str$ 1
,1 2
new3 6 
RouteValueDictionary7 K
(K L
newL O
{P Q

ControllerR \
=] ^
$str_ f
,f g
Actionh n
=o p
$strq ~
}	 Ä
)
Ä Å
)
Å Ç
;
Ç É
} 	
public   
async   
Task   
<   
ActionResult   &
<  & '
Item  ' +
>  + ,
>  , -
DeleteByIdAsync  . =
(  = >
Guid  > B
id  C E
,  E F
CancellationToken  G X
cancellationToken  Y j
)  j k
{!! 	
var"" 
existingItem"" 
="" 
await"" $
repo""% )
."") *
GetItemAsync""* 6
(""6 7
id""7 9
,""9 :
cancellationToken""; L
)""L M
;""M N
if## 
(## 
existingItem## 
is## 
null##  $
)##$ %
{$$ 
return%% 
NotFound%% 
(%%  
)%%  !
;%%! "
}&& 
await(( 
repo(( 
.(( 
DeleteItemAsync(( &
(((& '
id((' )
,(() *
cancellationToken((+ <
)((< =
;((= >
return)) 
RedirectToAction)) #
())# $
$str))$ 1
,))1 2
new))3 6 
RouteValueDictionary))7 K
())L M
new))N Q
{))R S

Controller))T ^
=))_ `
$str))a h
,))h i
Action))j p
=))q r
$str	))s Ä
}
))Å Ç
)
))É Ñ
)
))Ñ Ö
;
))Ö Ü
}** 	
public,, 
async,, 
Task,, 
<,, 
ActionResult,, &
>,,& '
GetAllAsync,,( 3
(,,3 4
CancellationToken,,4 E
cancellationToken,,F W
),,W X
{-- 	
var.. 
items.. 
=.. 
await.. 
repo.. "
..." #
GetItemsAsync..# 0
(..0 1
cancellationToken..1 B
)..B C
;..C D
ViewBag00 
.00 
Items00 
=00 
items00 !
;00! "
return11 
View11 
(11 
$str11 "
)11" #
;11# $
}22 	
public44 
async44 
Task44 
<44 
ActionResult44 &
<44& '
Item44' +
>44+ ,
>44, -
GetByIdAsync44. :
(44: ;
Guid44; ?
id44@ B
,44B C
CancellationToken44D U
cancellationToken44V g
)44g h
{55 	
var66 
item66 
=66 
await66 
repo66 !
.66! "
GetItemAsync66" .
(66. /
id66/ 1
,661 2
cancellationToken663 D
)66D E
;66E F
if88 
(88 
item88 
is88 
null88 
)88 
{99 
return:: 
NotFound:: 
(::  
)::  !
;::! "
};; 
return<< 
View<< 
(<< 
$str<< 
)<< 
;<<  
}== 	
public?? 
async?? 
Task?? 
<?? 
ActionResult?? &
>??& '
UpdateByIdAsync??( 7
(??7 8
Guid??8 <
id??= ?
,??? @
ItemDto??A H
itemDto??I P
,??P Q
CancellationToken??R c
cancellationToken??d u
)??u v
{@@ 	
varAA 
existingItemAA 
=AA 
awaitAA $
repoAA% )
.AA) *
GetItemAsyncAA* 6
(AA6 7
idAA7 9
,AA9 :
cancellationTokenAA; L
)AAL M
;AAM N
ifBB 
(BB 
existingItemBB 
isBB 
nullBB  $
)BB$ %
{CC 
returnDD 
NotFoundDD 
(DD  
)DD  !
;DD! "
}EE 
ItemGG 
updatedItemGG 
=GG 
existingItemGG +
withGG, 0
{HH 
NameII 
=II 
itemDtoII 
.II 
NameII #
,II# $
PriceJJ 
=JJ 
itemDtoJJ 
.JJ  
PriceJJ  %
,JJ% &
}KK 
;KK 
awaitMM 
repoMM 
.MM 
UpdateItemAsyncMM &
(MM& '
updatedItemMM' 2
,MM2 3
cancellationTokenMM4 E
)MME F
;MMF G
returnNN 
RedirectToActionNN #
(NN# $
$strNN$ 1
,NN1 2
newNN3 6 
RouteValueDictionaryNN7 K
(NNK L
newNNL O
{NNP Q

ControllerNNR \
=NN] ^
$strNN_ f
,NNf g
ActionNNh n
=NNo p
$strNNq ~
}	NN Ä
)
NNÄ Å
)
NNÅ Ç
;
NNÇ É
}OO 	
publicPP 
asyncPP 
TaskPP 
<PP 
ActionResultPP &
>PP& '
DeleteMiddlePagePP( 8
(PP8 9
GuidPP9 =
idPP> @
,PP@ A
CancellationTokenPPB S
cancellationTokenPPT e
)PPe f
{QQ 	
varRR 
itemRR 
=RR 
awaitRR 
repoRR !
.RR! "
GetItemAsyncRR" .
(RR. /
idRR/ 1
,RR1 2
cancellationTokenRR3 D
)RRD E
;RRE F
returnTT 
ViewTT 
(TT 
itemTT 
)TT 
;TT 
}UU 	
publicVV 
asyncVV 
TaskVV 
<VV 
ActionResultVV &
>VV& '
UpdateMiddlePageVV( 8
(VV8 9
GuidVV9 =
idVV> @
,VV@ A
CancellationTokenVVB S
cancellationTokenVVT e
)VVe f
{WW 	
varXX 
itemXX 
=XX 
awaitXX 
repoXX !
.XX! "
GetItemAsyncXX" .
(XX. /
idXX/ 1
,XX1 2
cancellationTokenXX3 D
)XXD E
;XXE F
returnZZ 
ViewZZ 
(ZZ 
itemZZ 
)ZZ 
;ZZ 
}[[ 	
}\\ 
}]] ﬁ
fC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Settings\MongoDbSettings.cs
	namespace 	
RunnersBlogMVC
 
. 
Settings !
{ 
public 

class 
MongoDbSettings  
{ 
public 
string 
? 
Host 
{ 
get !
;! "
set# &
;& '
}( )
public 
int 
Port 
{ 
get 
; 
set "
;" #
}$ %
public 
string 
? 
ConnectionString '
{ 	
get		 
{

 
return 
$" 
$str #
{# $
Host$ (
}( )
$str) *
{* +
Port+ /
}/ 0
"0 1
;1 2
} 
} 	
} 
} 