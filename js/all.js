$(function(){
	$("#allCate").toggle(function(){
		$(".head a").removeClass("cur");
		$(".searchZone").hide();
		$("#searchZone").find("img").attr("src","images/ico2.png");
		$(this).addClass("cur");
		$(this).find("img").attr("src","images/ico1h.png");
		$(".allCate").show();	
		$("#bgColor").show();	
	},function(){
		$(this).removeClass("cur");
		$(this).find("img").attr("src","images/ico1.png");
		$(".allCate").hide();	
		$("#bgColor").hide();	
	})
	
	$("#searchZone").toggle(function(){
		$(".head a").removeClass("cur");
		$(".allCate").hide();
		$("#allCate").find("img").attr("src","images/ico1.png");
		$(this).addClass("cur");
		$(this).find("img").attr("src","images/ico2h.png");
		$(".searchZone").show();	
		$("#bgColor").show();	
	},function(){
		$(this).removeClass("cur");
		$(this).find("img").attr("src","images/ico2.png");
		$(".searchZone").hide();	
		$("#bgColor").hide();	
	})
	
	$(".allCate h3 i").toggle(function(){
		$(this).addClass("cur");	
		$(this).parent().next("ul").show();	
	},function(){
		$(this).removeClass("cur");	
		$(this).parent().next("ul").hide();		
	})
	
	$(".newsCate a").click(function(){
		$(".newsCate a").removeClass("cur");
		$(this).addClass("cur");	
	})
	
	$(".shopList h2").toggle(function(){
		$(this).find("i").addClass("open");
		$(this).next().slideDown(700);	
	},function(){
		$(this).find("i").removeClass("open");
		$(this).next().slideUp(700);	
	})
	$(".shopList h3").toggle(function(){
		$(this).find("i").addClass("open");
		$(this).next().slideDown(700);	
	},function(){
		$(this).find("i").removeClass("open");
		$(this).next().slideUp(700);	
	})	
})