jQuery(function($) {
	/* back top
	--------------------*/
	$('.backtop').on('click', function(e) {
		e.preventDefault();
		$('html, body').animate({ 
			scrollTop: '0', 
		}, 400);
	});
	
	$('[data-toggle="tooltip"]').tooltip();
	$('[data-toggle="popover"]').popover({ trigger: "manual" , html: true, animation:false})
	.on("mouseenter", function () {
		var _this = this;
		$(this).popover("show");
		$(".popover").on("mouseleave", function () {
			$(_this).popover('hide');
		});
	}).on("mouseleave", function () {
		var _this = this;
		setTimeout(function () {
			if (!$(".popover:hover").length) {
				$(_this).popover("hide");
			}
		}, 300);
	});
	
	$('.toggle-nav-open').on('click', function() {
		$('#navigation').slideToggle(300);
		$('.navbar-breadcrumb').slideToggle(150);
		$(this).toggleClass('active');
	});
	
	$('#truyen-background').on('change', function() {
		$('body').css({ 'background-color' : $(this).val() });
		if( $(this).val() == '#232323' ) {
			$('.chapter-content').css({ 'color' : '#b3b3b3' });
			Cookies.set( 'truyen-background', $(this).val() );
		} else {
			$('.chapter-content').css({ 'color' : '#2b2b2b' });
			Cookies.set( 'truyen-background', $(this).val() );
		}
	});
	if( $('body').hasClass('single') ) {
		$('body').css({ 'background-color' : Cookies.get( 'truyen-background' ) });
		if( Cookies.get( 'truyen-background' ) == '#232323' ) {
			$('.chapter-content').css({ 'color' : '#b3b3b3' });
		} else {
			$('.chapter-content').css({ 'color' : '#2b2b2b' });
		}
		$('#truyen-background').val( Cookies.get( 'truyen-background' ) );
	}
	
	$('#font-chu').on('change', function() {
		$('.chapter-content').css({ 'font-family' : $(this).val() });
		Cookies.set( 'font-chu', $(this).val() );
	});
	$('.chapter-content').css({ 'font-family' : Cookies.get( 'font-chu' ) });
	$('#font-chu').val( Cookies.get( 'font-chu' ) );
	
	$('#size-chu').on('change', function() {
		$('.chapter-content').css({ 'font-size' : $(this).val() });
		Cookies.set( 'size-chu', $(this).val() );
	});
	$('.chapter-content').css({ 'font-size' : Cookies.get( 'size-chu' ) });
	$('#size-chu').val( Cookies.get( 'size-chu' ) );
	
	$('#line-height').on('change', function() {
		$('.chapter-content').css({ 'line-height' : $(this).val() });
		Cookies.set( 'line-height', $(this).val() );
	});
	$('.chapter-content').css({ 'line-height' : Cookies.get( 'line-height' ) });
	$('#line-height').val( Cookies.get( 'line-height' ) );
	
	/*	Full trang
	------------------------------*/
	$('#fluid-yes').on('mousedown', function() {
		if( $(this).prop('checked', true) ) {
			$('.single-chapter').addClass('container-fluid').removeClass('container');
			Cookies.set( 'fluid', $(this).val() );
		}
	});
	if( Cookies.get( 'fluid' ) == 'yes' ) {
		$('.single-chapter').addClass('container-fluid').removeClass('container');
		$('#fluid-yes').attr('checked', 'checked');
	}
	$('#fluid-no').on('mousedown', function() {
		if( $(this).prop('checked', true) ) {
			$('.single-chapter').addClass('container').removeClass('container-fluid');
			Cookies.set( 'fluid', $(this).val() );
		}
	});
	if( Cookies.get( 'fluid' ) == 'no' ) {
		$('.single-chapter').addClass('container').removeClass('container-fluid');
		$('#fluid-no').attr('checked', 'checked');
	}
	
	/*	KhÃ´ng cÃ¡ch Ä‘oáº¡n
	------------------------------*/
	$('#onebreak-yes').on('mousedown', function() {
		if( $(this).prop('checked', true) ) {
			$('.chapter-content p').css({ 'margin-bottom' : '10px' });
			$('.chapter-content br').after('<br>');
			Cookies.set( 'onebreak', $(this).val() );
		}
	});
	if( Cookies.get( 'onebreak' ) == 'yes' ) {
		$('.chapter-content p').css({ 'margin-bottom' : '10px' });
		$('.chapter-content br').after('<br>');
		$('#onebreak-yes').attr('checked', 'checked');
	}
	$('#onebreak-no').on('mousedown', function() {
		if( $(this).prop('checked', true) ) {
			$('.chapter-content p').css({ 'margin-bottom' : '0px' });
			$('.chapter-content br').nextAll('br').remove();
			Cookies.set( 'onebreak', $(this).val() );
		}
	});
	if( Cookies.get( 'onebreak' ) == 'no' ) {
		$('.chapter-content p').css({ 'margin-bottom' : '0px' });
		$('.chapter-content br').nextAll('br').remove();
		$('#onebreak-no').attr('checked', 'checked');
	}
});

jQuery(function($){
	$chapterContent = $('.chapter-content');
	var curDown = false,
	curYPos = 0,
	curXPos = 0;
	$chapterContent.mousemove(function(m){
		if( curDown === true ){
			$(window).scrollTop($(window).scrollTop() + (curYPos - m.pageY)); 
			$(window).scrollLeft($(window).scrollLeft() + (curXPos - m.pageX));
		}
	});

	$chapterContent.mousedown(function(m) {
		curDown = true;
		curYPos = m.pageY;
		curXPos = m.pageX;
	});

	$chapterContent.mouseup(function() {
		curDown = false;
	});
	
	$chapterContent.on('dragstart', function(event) { event.preventDefault(); });
});