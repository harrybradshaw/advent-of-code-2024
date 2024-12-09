﻿namespace AdventOfCode2024.Day9;

public class Day9Input
{
    public const string Sample = "2333133121414131402";

    public const string Puzzle =
        "7180145863894590673537879271314880852946453430325723595387946731371171715049146885612220926120738589618397567123195019492468767869117191772943948681989557409324432163359332717293511681726568157211214076456544717760368210531944682264857880728768249773703473877918518368506970581614788098105975595961942090913744921918334214629688269439848311385150806778173569716545964151398240396174595542774062792493409725327473136860591771148554834240424130239310578565546835517071649353299238163083669483151711687281844670212974315332249926625392974291538897229312199784798789616026802618635399298049421050107628761040489718866093393115664551301635326585218169759295505681911411602865531013455352596275133246689775631768249328972730522085128287719319481150687674726839798052517316747794369414883884802824805699423290442493272456173428469259419414821898933716625110439478588561795237556824614960229660818595142095543183484868987440295715918087832540674459911266162185415898718731849937282796523819118635158742249088101713446889666210111337794293153371662239523512695210106798516142137927561744417447129032336345216343196151957448613981472877161745288566651897278077646054837571543592539376333945303416993789138433571184315441695778747521811035922730938170683336251237403839155649639738277515386023746916227725163288349389966550532462554246539767959458392210896387441176911596469767774369383339727297619853234359574086924042308926323524701730894730762782803979246210738931873012962138488263941510962237323375568621611062872959224751209715426733693595568965247722437189859557106426101570379212316820626736774258262834374032793143564246746034174670428999186135112631735860765981826812154648729662501890852488644936565368177552648496137771356875465593293075235945275221591515596612366697584510106027575474844160457652614869106437986574976993977889364193878170505494169142792074512012793573212077647792187269495025823188263187726665849257208938724728431246657842635386538278703895418326344740733663658153261727364479895272946897179084241785649718588534336316581572426958538165121490982329625760157145198931547871333226674977583778218995505895471231101843754841321244932450589917939132712256455794656657309754922662477978888281153741189353446549316545993736586537755440916080878889182055294725849066399940419425726234953256705237494630802130302728671863659922913268467471535782303455775480555817389071187757289920185087737059515068482780815890506687489458888643108627683712942193672940128887275114533349511847917466239750452580833035287435163526594847182230856218765945893050958164424632128969521299458620684445927630432129199711957334124926802626326560957445461797398030584431751441753852187428417740818863793911481061383179983847992871977296361871928546405125309243912127399899451587229185339596639338335019579930724848885562793355454159927655665466954673232729631790713210952321728853826919313671741848722249742412439380785478273899569369611662418360622650643814126627624267505250327648488365312782111922889143699727319476794583169139681560797492327723494629937195536890446972913973629339556283238849372578503850723883965314151776566093406389325722448710369413925186586285128122875054934632483873362995933683404328984385222967416741577814483335169897466347618342187324583574971595974357124181513582822187102155192723536713726539289986122591431191909315167823847644231241319150117521285316353625886034317341271748474648151485194842714678276761595769194865304494882611902591454029646012268333463169639710184721191555452230609871929450944020827489608237581435353923383987176569704865969346732063311848229459128367259838114676989128448730807037775719125759385092194818609123228589998421658624874436939196387276213197941987368432885245711854342539467578466317625444557121873055489210311556515195643145465627218257402479509769102760601830697090211591379187574155445474265020889474177213268862808876479773631622602186124215192610338398617514346845479118195892888428646954655085199265589954127685612626168691848539665280605384742420505732713287175483841786256433414143951162785731116494654835635058506452673914245120267949795159559761692261735337536421448197222081532446966296186574944014297670865549403177899970488062658224444532405472645131127616676430601238739012178320212289576639233539244018897558246914994247103849314443871221129955555868426751181718875236892584628196995154676966797364601885808266634684612814992069929638334673497275483310681932325426668693237185267910332552746418441552733855204535815760168992578385445776621756396154716914242465608416456046669274492286896210167533482852849295582431983635316776686731428656735935397863936849201389987553627260199725122440771912182086567748115337304537157488254488156254913552414138274734205596476811989254652387335167149796993534481710283756798566371352494878841142938895457429238493843327616598117068485497778532955498323017395559127233275483141974658079648917187621311560727769648035184233406581435589891782843169481875762364174357224890557050336346363676475588295241555675805647453640138316624920292392537513783079778062771953632690934876265673322380597213178623923718545327417121718699806073592144269139484754464375714680114227617775679510143158613413672915838724865749227438969014263345305825625377155620691866668181142093319560311971468065702271586569417045201658764380985193287369408277329964343442398266155430214723396476156990792777724549112628491394454669705444425852513598464787766927222393923780239590539587395379538863934430867722392494411888878420972648396276981884529081413451656314109162897040911391237511821558682944106369903939395938907984751117813427192668609389607572522135614117121082394960654265238556192249543150174112723959877694768029485283374972559669478490427143318615683988882711555055456763286888128574299936684775751583714160848714845440977218512018814685271430704636485917265630184116376940682642996354477188196976837668779122659188643720228447945779805064228417747542754835835615444113294777216176895277624394598243412574397433391917584050982839377055578630648825788856452892533535414131659434814146519147117346509962932693771249496351708613718952165970748189165756134394688584775537629834443385573793396422831248599798908144837547664511655930821075978191858818813558319755605058268176579457813626375670568180691741987318989084478073375468341162417532844577729221403743268558335717574198496398383862424280545458534448718097286438271850276897698265355835596937582119766321367286751193855360113716949454107115285774707584618037649239562453585763995837946187154744404481527893511151571455985035945045556030984477788024284399462448496385754294518356933450813857832591172481165781441869435230986794644810429745981248688114338993168116669272481417863746145752909169484236585266734295756889624593242638484932292162621730125468223039914876811897811564821357663167966599769797264436445519219130821881129540766821378450366691974169215678792348317785806022749245363649161895269254253915497862862554718237959885136162479765298527908287614878726727215027403335399819125592376093545166369783537691216634492931814740934215906226313981923957599888677988518113711838876547646311603570277241997070302342203042842418645022829099706010337039977251386683459952935169274456919878394147392497976276729212689089146742325828439328738424396775277982123512663630752867603982904135215663755227779680104391833730566125763183689571297978446621687879792360122464363243246269757447542679835185909460227647593774538875342933902070899380242443326856566039359620844279316667997899789610646048217224949214804471902172278282255970497999436058798739647848102380205399604854906943444530619147827035913481854279544262185349359919872743691757951532928140854135855272257517395021969793975255893491442932875878568513918230451837721789722730128191567523217915303413651261688257757031217548806066459298361865596029784142904396279037873782632179639798983541968971586391179274806538532097526068312287336647905657185467963837693226359581706576995489679314246343913658533886596441274635926897966266686424653948534744572777662921658892886519139629456424866147932368842980911032798517375461869996654518347610701116593163411353204739681784473297632225666868233744411837268978666587681293201032427844988555439815339669646467346261394217195034435873815177321562584426533443205494119517598843741647708942509279576274595653326149945729362326186687441876665738547623865091178669559212106067901489147458108276773373115667343298315241322829253840817720608053131895802236591695856798361183207237617288542866481933439830156986817278557763446668932030215739601095426413916794948226289868706742698617815165461925733714205875794515978069993298692183778110687454636341542747272190367558181132579413363697808643996317251322144931265929335687751146462433984324103688562446145347488559992084492353726982611150635650691869638089511255805694527225893726774871428783723978118526749012527261411273453225518945598372565697242291944398576443601289678313305435585880513265907427743613409352733130316820364340412879384928796142486339904854494179179923462950357080476027895789179021334886938734115623151341666554658511887145192443526821348787231157812267725889855274117994699195574123412032137813891937411543796258259148941938523275836088708385209557363345363811636052543053682791843046211131197150761969977147215232437510773753585045775271284760209235433719151692136669737717911080229332783398948754474075506889482579992547848588982011215098228765781756187484329373277716247918227463868872821136443040851333309046476884933981501313738512148169582814842811491923911456231073858677831348707187166569249628783949535714301349665883432496721745511632681843584822945298873771654913641610982555933767275967103451576919831912269236452487294098222975215427414978401539794354618411842713929891434150733834722382674052334512976535425494301885864932565542269662262826628973885565834360579029327576989029918540982222396915988291663092982917921927791422877481931370255730654196396430933381845372627277651541702293425074967462199046406473541985138851476082633894833724858497142139765626731044599386566057576150614169474288903127266027378674983471578623153189326213121351623161935985858413652654754591848510868475249537948986758570889433587326955717765076385256539773688754208256591571383929969187107658237319232794415760817299613284355892237570671960176032928852994427417357188486779087522575449914863811231467351876741542371591968738874561913922461497853721161595592232492676267492825016925413724557816683244825858952887014943027441785625569273983353287741645175281152040361920482052412086968987435443723557184285468878335740761730912843152823739775222741863615275469485041722727297224383137648371995289383597218673466433583472591649231989267492555387225832938512169550765222842957952413297996374473409493824712669743637539327812951044984174127678774665875836433138134948671214208281554072435626529512348280339924139939243752141332662619243048399022261052821123819160304544134153154531327869905098239685575527981711719391853096232858794826333092963417417687967661575566579892397877672680733694735958823917644893592839148938663995265132579551891796449367844595937170731468715514904667589234125840276439984859954137787592443075661757494447555125775895443422686711396114638082525913518146256931723422411837634255669420481421471967895399403131945814913416352241579095131356546928209193572369893791821180537035652734629383393560587591741689963493225461907711702458486137854649715639255347936839569290744775801841321040362031382616773273123968412175539621832879596995889779125750802251566367815341181051422064747388457851464933968584754027955155395033378697743150664748844127685441862034446694214298737184443613479085357465757020134033373198656446233656892538719424106879676580372949124371638547393110896782183374215198657369924432736029896084489814719441908856248744981541957014596632664711476242857815316448474556277673379875815124874611475530488578785129856198455516131172815078756261502688281968199056127646666981676214951939372790784870799740196520581881649466604464646935128093864712842291866767797066193913663423609891709293937481431923658719509253891755658858305627863635958399574354876116341425682154661772999896233641754426881661404726406879376480341640293924936395182258189341292852504091941999832150791888331850715936482420437191537240628311767392933164862340521611301259631022821598637799425393589832914958662746678268901671896286902051752980237188335682209084929140811840988835918629408897885099784239886255336365959015961539176248974990686340573032948985434082314762531739956691986331602926505869599946947557324463277710863580148850269949421675853788887954514555983980668025283340181488438693595732164794196270631565914753288247121174354851338771233848127084391361539285786260698576435176771322697250629846497297861881218064982937939388864120112021463178202833244236917454602770116990659110162147493434847123732050357912217677728120667745228387473654484016104066795032321743743579829548269395634692173531781097158032827384492319459687485591841930963255571747526593321348896097688159379235815811586259941017329335977042528699284995371538867967268914718789724029666823396078959438253932947934804026507578861414146374971217207748865057268878128614337884694365196141499795397148417381911895568147303257842076238355295911819921421242806477363369535940319280811849503131262715965766592585672014169890443877979032907035651559326186539392444267339570715865935616463065449914748856369140247655344350668928939947277641376786514540401272369561609351412244976384418013253244891195641670123288434960705893655767448186978463153880471329949617147297223767441019104833144471753469157671387917878016386011186159605984685291601634654681797042597510407948524452754725523183611781109113989254688787642277497017507980703335542086793321809214747893922783443266823026174719696731571239642675355025305387269047157643545263248596106393488545252453175581902061775740647788387033711530918649215339718582656898818429454243729912575957262775281122165372761415111841713140249226901072862927229316959132944251896850316171907945643861466266422446682243689878756361213725952520391470595154668296104017923683681087817977928028671847697835469635322015475055107234622790553627756085442840669518747937243889239169961149795155267636589084367632782585573982205394465777268184238747673042288519415780694128992094782072546510608032145232974093142460101429473717164393194587569689255668353047467853785370788552795635557091454070571125773492911543885092109388378639391023669034966778665931844924989444733247661453961145644082452946202617232855272432774671158080465833542582749936969623503986826678971045323730174446554460419059962681917665696780352360166863361212648118214062333785537965806525193994206254667192788956548616141775718868475620759025695793826393116314862322205696662468258567713074531782309962185490205464904698814177556545145150319640621250775884519825947761925253188511419869856360416579696684708546541872461522655447785259354857281449549285457243864353197519568716674784401620466330831121831037969710654925684181917822751992555817546163594182787084574034126199333570191435895590193558622597383038925673826454343977435258666166192658848067445515965671699888426725378011987028777496916672117699392391182966141531775857326545124553485978591529672729979610408316845464545240299833501895542025487139441679831177258263418587936451149931523314794123567216716093381925125372147587609248388621344092509635918295483694408557966426116118853016856347488244591779565838205673727942956382211078137870617113259911615995434265839473273125127235121445288779212228549447661375558492614360964652621935749155621331304028191071876358996850649499304719893933946826358382232131806568487686273050909647771263619987929519489246727076826259403650316215196337936669882966537828648528494913187567694028326211379776625858816318467491549418191253544753233775487891179164684373818732126431133395743647127382932153468998501586294493712526485326887757456734361249454834548877871992605486955092678315122447698824851864507830532537185756645198524564886695728144447965563665946497342526821320382529605511607419333230276267791294384013794213901846837586116014298054678529352470713466326472175072788888525635695745444965916931272583112197405486104996944930487730819452993944246663241671277641897270879150673653346269251941268346343694567838944257677065603140238050628553139852637610526432509796497430155624994784791990518181557669695644745460139943893058367877871858866546731332959867344338198697732323452626612958668121631671888691882153467865925050323311609024896233555927942331122723834856781961589294662494538239997196161973357939414627232596653977675333177084829416914684753835615256303860373416704140717571467331564221312538926994617647132198892150789536408375743228605266286864131575898083763746477232183656449396623353337985804963585836799362813282377739829911286752368299797169408150889541508221671197546068763244981191411850327625819881812629595621454970433777606127409371698431651329681928298939903645722453889988561776419916659421401488213814778430918717762811868099365713757027655134447693399614413339721428969120945468173081896095311682242632539498501752529047382374569752576591167526662713922868368410489369323145918235794039146318284182153843116666976440733342161326324067375136643319344072117260906812918371609842824648946188535861955857884442201665987755672844809136387385863269479812708617949034606495196428403499687671657357176790901771899060956220376997542821318858671962777160201794543783494448218013141635767283848732114851961784745327108560128439492854248280502472661094382479287398559112954115179956369238518046828031181854463773113188121141242710285057144516387424693156636813214655464068308597321816751230245913562180594045487277651982646810761331528659372732458128249364497731685524895722732363905790106358704581436381135956603067157917699234546435578328124922467999329842777358501969103867228338899565339184894094344434451126862570735725904578564076657248364641889281109754163364826724393754189739743415728225131142236050598241321374605036715811848749494427265043747015739144485535873311907565623549648284659693762118927320268562907746295551291112516875689134134077265792993448491199263276701694635387476371141796287281329159845412744993984678693331218945512121901842557411683650847187362743413977943847342840381695568966594193444281161889289695607185337290906640627775734387514073209057659739377885488652338642977675579623478367275943149856997080327516179572391975709912193764686266424328309524872536823569766929149699796867574432641617925945997143302776258687634862818375474234813137621329319774753752485597693651165322745857221884107749365060461360857977909453104581747765216394741322749695705155361799227948299470506663687412104591464862496694606744634320488290136528446449427156713385529295456021525433936744601615199987784932315197165797724596453581186758983245427739594436272826703169569013122998492289684162811371622878186478696296626333597834391656978195885924569067357359884326132240828218886669212830947361353134214645424532833280115762299637519596691773259141925599398348762178423196675162145772675199853178645783428955259698578420556320786623189976817652437972994283918098877270765093499158963581437748731828943651213894121024816542827673427237965511412179906292988123845140981839968879806983797434809527203288745468207622795872777212871840627746113038489262877083743450707475402926431645716912335580589117566176935780607917436835796686105579893973108148984363476847679817973555927415526184672282906986595442512880525916158948808347119762812240909014128499633258554884188645389690793196387677699911497094244629651266918735178688317921822685296492326374782856161028306341533830891395443923222121331073745229268640717845572181404643539193886317634876314616687483169556584711492439317213104734277472748672153763231986922721374537962122771393468050767945428419557465627778816617413780378411292739218577126522639657922672306453112830967439418";
}