Î!
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
:		# $

Controller		% /
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
}99 á
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
}   ‚<
iC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Controllers\ItemsController.cs
	namespace		 	
RunnersBlogMVC		
 
.		 
Controllers		 $
{

 
public 

class 
ItemsController  
:! "

Controller# -
{ 
private 
readonly 
IItemsRepository )
repo* .
;. /
public 
ItemsController 
( 
IItemsRepository /
repo0 4
)4 5
{ 	
this 
. 
repo 
= 
repo 
; 
} 	
[ 	
HttpGet	 
] 
[ 	
AllowAnonymous	 
] 
public 
async 
Task 
< 
ActionResult &
>& '
GetItemsAsync( 5
(5 6
)6 7
{ 	
var 
items 
= 
await 
repo "
." #
GetItemsAsync# 0
(0 1
)1 2
;2 3
ViewBag 
. 
Items 
= 
items !
;! "
return 
View 
( 
$str "
)" #
;# $
} 	
[ 	
HttpGet	 
] 
[ 	
	Authorize	 
( 
Roles 
= 
$str "
)" #
]# $
public   
ActionResult   

CreateItem   &
(  & '
)  ' (
{!! 	
return"" 
View"" 
("" 
)"" 
;"" 
}## 	
[%% 	
HttpPost%%	 
]%% 
[&& 	$
ValidateAntiForgeryToken&&	 !
]&&! "
['' 	
	Authorize''	 
('' 
Roles'' 
='' 
$str'' "
)''" #
]''# $
public(( 
async(( 
Task(( 
<(( 
ActionResult(( &
>((& '
CreateItemAsync((( 7
(((7 8
CreateItemDto((8 E
itemDto((F M
)((M N
{)) 	
Item** 
item** 
=** 
new** 
(** 
)** 
{++ 
Id,, 
=,, 
Guid,, 
.,, 
NewGuid,, !
(,,! "
),," #
,,,# $
Name-- 
=-- 
itemDto-- 
.-- 
Name-- #
,--# $
Price.. 
=.. 
itemDto.. 
...  
Price..  %
,..% &
CreatedDate// 
=// 
DateTimeOffset// ,
.//, -
UtcNow//- 3
,//3 4
}00 
;00 
await22 
repo22 
.22 
CreateItemAsync22 &
(22& '
item22' +
)22+ ,
;22, -
return33 
RedirectToAction33 #
(33# $
$str33$ .
)33. /
;33/ 0
}44 	
[66 	
HttpGet66	 
]66 
[77 	
	Authorize77	 
(77 
Roles77 
=77 
$str77 "
)77" #
]77# $
public88 
async88 
Task88 
<88 
ActionResult88 &
<88& '
Item88' +
>88+ ,
>88, -
EditItemAsync88. ;
(88; <
Guid88< @
id88A C
)88C D
{99 	
var:: 
item:: 
=:: 
await:: 
repo:: !
.::! "
GetItemAsync::" .
(::. /
id::/ 1
)::1 2
;::2 3
if;; 
(;; 
item;; 
is;; 
null;; 
);; 
{<< 
return== 
NotFound== 
(==  
)==  !
;==! "
}>> 
return?? 
View?? 
(?? 
item?? 
)?? 
;?? 
}@@ 	
[BB 	
HttpPostBB	 
]BB 
[CC 	
	AuthorizeCC	 
(CC 
RolesCC 
=CC 
$strCC "
)CC" #
]CC# $
publicDD 
asyncDD 
TaskDD 
<DD 
ActionResultDD &
>DD& '
EditItemAsyncDD( 5
(DD5 6
GuidDD6 :
idDD; =
,DD= >
ItemDD? C
itemDtoDDD K
)DDK L
{EE 	
varFF 
existingItemFF 
=FF 
awaitFF $
repoFF% )
.FF) *
GetItemAsyncFF* 6
(FF6 7
idFF7 9
)FF9 :
;FF: ;
ifGG 
(GG 
existingItemGG 
isGG 
nullGG  $
)GG$ %
{HH 
returnII 
NotFoundII 
(II  
)II  !
;II! "
}JJ 
ItemLL 
updatedItemLL 
=LL 
existingItemLL +
withLL, 0
{MM 
NameNN 
=NN 
itemDtoNN 
.NN 
NameNN #
,NN# $
PriceOO 
=OO 
itemDtoOO 
.OO  
PriceOO  %
,OO% &
}PP 
;PP 
awaitRR 
repoRR 
.RR 
UpdateItemAsyncRR &
(RR& '
updatedItemRR' 2
)RR2 3
;RR3 4
returnSS 
RedirectToActionSS #
(SS# $
$strSS$ .
)SS. /
;SS/ 0
}TT 	
[VV 	
HttpGetVV	 
]VV 
[WW 	
	AuthorizeWW	 
(WW 
RolesWW 
=WW 
$strWW "
)WW" #
]WW# $
publicXX 
asyncXX 
TaskXX 
<XX 
ActionResultXX &
<XX& '
ItemXX' +
>XX+ ,
>XX, -
DeleteItemAsyncXX. =
(XX= >
GuidXX> B
idXXC E
)XXE F
{YY 	
varZZ 
itemZZ 
=ZZ 
awaitZZ 
repoZZ !
.ZZ! "
GetItemAsyncZZ" .
(ZZ. /
idZZ/ 1
)ZZ1 2
;ZZ2 3
if[[ 
([[ 
item[[ 
is[[ 
null[[ 
)[[ 
{\\ 
return]] 
NotFound]] 
(]]  
)]]  !
;]]! "
}^^ 
return__ 
View__ 
(__ 
item__ 
)__ 
;__ 
}`` 	
[bb 	
HttpPostbb	 
]bb 
[cc 	
	Authorizecc	 
(cc 
Rolescc 
=cc 
$strcc "
)cc" #
]cc# $
publicdd 
asyncdd 
Taskdd 
<dd 
ActionResultdd &
<dd& '
Itemdd' +
>dd+ ,
>dd, -
DeleteItemPOSTAsyncdd. A
(ddA B
GuidddB F
idddG I
)ddI J
{ee 	
varff 
existingItemff 
=ff 
awaitff $
repoff% )
.ff) *
GetItemAsyncff* 6
(ff6 7
idff7 9
)ff9 :
;ff: ;
ifgg 
(gg 
existingItemgg 
isgg 
nullgg  $
)gg$ %
{hh 
returnii 
NotFoundii 
(ii  
)ii  !
;ii! "
}jj 
awaitll 
repoll 
.ll 
DeleteItemAsyncll &
(ll& '
idll' )
)ll) *
;ll* +
returnmm 
RedirectToActionmm #
(mm# $
$strmm$ .
)mm. /
;mm/ 0
}nn 	
}oo 
}pp ˜
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
}kk À
_C:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\DTO\CreateItemDto.cs
	namespace 	
RunnersBlogMVC
 
. 
DTO 
{ 
public 

record 
CreateItemDto 
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
} ’
YC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\DTO\ItemDto.cs
	namespace 	
RunnersBlogMVC
 
. 
DTO 
{ 
public 

record 
ItemDto 
{ 
public 
string 
Name 
{ 
get  
;  !
init" &
;& '
}( )
public 
decimal 
Price 
{ 
get "
;" #
init$ (
;( )
}* +
} 
} ¯
XC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Extensions.cs
	namespace 	
RunnersBlogMVC
 
{ 
public 

static 
class 

Extensions "
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
} è
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
} "
UC:\Users\Marius Milius\source\MainRepo\RunnersBlog-Web-Site\RunnersBlogMVC\Program.cs
var		 
builder		 
=		 
WebApplication		 
.		 
CreateBuilder		 *
(		* +
args		+ /
)		/ 0
;		0 1
BsonSerializer 
. 
RegisterSerializer !
(! "
new" %
GuidSerializer& 4
(4 5
BsonType5 =
.= >
String> D
)D E
)E F
;F G
BsonSerializer 
. 
RegisterSerializer !
(! "
new" %$
DateTimeOffsetSerializer& >
(> ?
BsonType? G
.G H
StringH N
)N O
)O P
;P Q
ConfigurationManager 
configuration "
=# $
builder% ,
., -
Configuration- :
;: ;
builder 
. 
Services 
. #
AddControllersWithViews (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
builder 
. 
Services 
. 
AddSingleton 
< 
IItemsRepository .
,. /
MongoDbItemsRepo/ ?
>? @
(@ A
)A B
;B C
var 
settings 
= 
configuration 
. 

GetSection '
(' (
nameof( .
(. /
MongoDbSettings/ >
)> ?
)? @
.@ A
GetA D
<D E
MongoDbSettingsE T
>T U
(U V
)V W
;W X
builder 
. 
Services 
. 
AddSingleton 
< 
IMongoClient *
>* +
(+ ,
serviceProvider, ;
=>< >
{ 
return 

new 
MongoClient 
( 
settings #
.# $
ConnectionString$ 4
)4 5
;5 6
} 
) 
; 
builder 
. 
Services 
. 
AddIdentity 
< 
ApplicationUser  
,  !
ApplicationRole" 1
>1 2
(2 3
)3 4
. 
AddMongoDbStores 
< 
ApplicationUser %
,% &
ApplicationRole' 6
,6 7
Guid8 <
>< =
(= >
settings 
. 
ConnectionString 
, 
$str &
) 
; 
var!! 
app!! 
=!! 	
builder!!
 
.!! 
Build!! 
(!! 
)!! 
;!! 
if$$ 
($$ 
!$$ 
app$$ 
.$$ 	
Environment$$	 
.$$ 
IsDevelopment$$ "
($$" #
)$$# $
)$$$ %
{%% 
app&& 
.&& 
UseExceptionHandler&& 
(&& 
$str&& )
)&&) *
;&&* +
app(( 
.(( 
UseHsts(( 
((( 
)(( 
;(( 
})) 
app++ 
.++ 
UseHttpsRedirection++ 
(++ 
)++ 
;++ 
app,, 
.,, 
UseStaticFiles,, 
(,, 
),, 
;,, 
app.. 
... 

UseRouting.. 
(.. 
).. 
;.. 
app00 
.00 
UseAuthentication00 
(00 
)00 
;00 
app11 
.11 
UseAuthorization11 
(11 
)11 
;11 
app33 
.33 

UseSwagger33 
(33 
)33 
;33 
app44 
.44 
UseSwaggerUI44 
(44 
)44 
;44 
app77 
.77 
MapControllerRoute77 
(77 
name88 
:88 	
$str88
 
,88 
pattern99 
:99 
$str99 5
)995 6
;996 7
app;; 
.;; 
Run;; 
(;; 
);; 	
;;;	 
≤
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
)' (
;( )
Task 
< 
IEnumerable 
< 
Item 
> 
> 
GetItemsAsync  -
(- .
). /
;/ 0
Task		 
CreateItemAsync		 
(		 
Item		 !
item		" &
)		& '
;		' (
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
)

& '
;

' (
Task 
DeleteItemAsync 
( 
Guid !
Id" $
)$ %
;% &
} 
} Ô#
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
} 	
public 
async 
Task 
CreateItemAsync )
() *
Item* .
item/ 3
)3 4
{ 	
await 
itemsCollection !
.! "
InsertOneAsync" 0
(0 1
item1 5
)5 6
;6 7
} 	
public 
async 
Task 
DeleteItemAsync )
() *
Guid* .
Id/ 1
)1 2
{ 	
var 
filter 
= 
filterBuilder &
.& '
Eq' )
() *
item* .
=>/ 1
item2 6
.6 7
Id7 9
,9 :
Id; =
)= >
;> ?
await 
itemsCollection !
.! "
DeleteOneAsync" 0
(0 1
filter1 7
)7 8
;8 9
} 	
public 
async 
Task 
< 
Item 
> 
GetItemAsync  ,
(, -
Guid- 1
Id2 4
)4 5
{ 	
var 
filter 
= 
filterBuilder &
.& '
Eq' )
() *
item* .
=>/ 1
item2 6
.6 7
Id7 9
,9 :
Id; =
)= >
;> ?
return 
await 
itemsCollection (
.( )
Find) -
(- .
filter. 4
)4 5
.5 6 
SingleOrDefaultAsync6 J
(J K
)K L
;L M
}   	
public!! 
async!! 
Task!! 
<!! 
IEnumerable!! %
<!!% &
Item!!& *
>!!* +
>!!+ ,
GetItemsAsync!!- :
(!!: ;
)!!; <
{"" 	
return## 
await## 
itemsCollection## (
.##( )
Find##) -
(##- .
new##. 1
BsonDocument##2 >
(##> ?
)##? @
)##@ A
.##A B
ToListAsync##B M
(##M N
)##N O
;##O P
}$$ 	
public%% 
async%% 
Task%% 
UpdateItemAsync%% )
(%%) *
Item%%* .
item%%/ 3
)%%3 4
{&& 	
var'' 
filter'' 
='' 
filterBuilder'' &
.''& '
Eq''' )
('') *
existingItem''* 6
=>''7 9
existingItem'': F
.''F G
Id''G I
,''I J
item''K O
.''O P
Id''P R
)''R S
;''S T
await(( 
itemsCollection(( !
.((! "
ReplaceOneAsync((" 1
(((1 2
filter((2 8
,((8 9
item((: >
)((> ?
;((? @
})) 	
}** 
}++ ﬁ
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