                    var grow = $("selectSub").getElementsByTagName("option").length; //组数
                    var selectOption = $("selectSub").getElementsByTagName("option");
                    var showGrow = 1;//已打开组
                    var selectCount = 0; //已选数量 
                    showSelect(showGrow);
                    var items = $("selectSub").getElementsByTagName("input");
                    function $(o){ //获取对象
	                    if(typeof(o) == "string")
	                    return document.getElementById(o);
	                    return o;
                    }
                    function openSelect(state){ //选择城市层关闭打开控制
	                    if(state == 1)	
	                    {
		                    $("selectItem").style.display = "block";
		                    $("selectItem").style.left = (document.body.offsetWidth - $("selectItem").offsetWidth)/2 + "px";
		                    $("selectItem").style.top = document.body.scrollTop + 100 + "px";		
	                    }
	                    else
	                    {
		                    $("selectItem").style.display = "none";
	                    }
                    }
                    function showSelect(id){
	                    for(var i = 0 ; i < grow ;i++)
	                    {
		                    $("c0" + selectOption[i].value).style.display = "none";
	                    }
	                    $("c0" + id).style.display = "block";
	                    showGrow = id;
                    }
                    function openObject(id,state){ //显示隐藏控制
	                    if(state == 1)
	                    $(id).style.display = "block";
	                    $(id).style.diaplay = "none";
                    }
                    function addPreItem(){	
	                    $("previewItem").innerHTML = "";
	                    var len　= 0 ;
	                    for(var i = 0 ; i < items.length ; i++)
	                    {
		                    if(items[i].checked == true)
		                    {
			                    var mes = "<input type='checkbox' checked='true' title='" + items[i].title + "' value='"+ items[i].value +"' onclick='copyItem(\"previewItem\",\"previewItem\");same(this);'>" + items[i].title;
			                    $("previewItem").innerHTML += mes;
		                    }
	                    }
                    }
                    function makeSure(){
	                    openSelect(0);
	                    copyItem("previewItem","makeSureItem");
	                    var objs = $("makeSureItem").getElementsByTagName("input");
	                    $("txtRange").value = "";
	                    for(var i=0; i<objs.length; i++)
	                    {
	                        $("txtRange").value += objs[i].value + ",";
	                    }
	                    if($("txtRange").value.length>0)
	                        $("txtRange").value = $("txtRange").value.substring(0,$("txtRange").value.length-1);
                    }
                    function copyHTML(id1,id2){
	                    $(id2).innerHTML = $("id1").innerHTML;
                    }
                    function copyItem(id1,id2){
                    	
	                    var mes = "";
	                    var items2 = $(id1).getElementsByTagName("input");
	                    for(var i = 0 ; i < items2.length ; i++)
	                    {
		                    if(items2[i].checked == true)
		                    {
			                    mes += "<input type='checkbox' checked='true' title='" + items2[i].title + "' value='"+ items2[i].value +"' onclick='copyItem(\"" + id2+ "\",\""+ id1 +"\");same(this);'>" + items2[i].title;
		                    }
	                    }
	                    $(id2).innerHTML = "";
	                    $(id2).innerHTML += mes;
                    }
                    function same(ck){
	                    for(var i = 0 ; i < items.length ; i++)
	                    {
		                    if(ck.value == items[i].value)
		                    {
			                    items[i].checked = ck.checked;
		                    }
		                }
	                    //ck.parentNode.removeChild(ck.nextSibling);
	                    //ck.parentNode.removeChild(ck);
	                    makeSure();
                    }	