$(document).ready(function(){

    $('.main-navbar__catalog-box-inner').on("click",function(){
        
        if ($( ".main-navbar__catalog-menu" ).hasClass('show')) {
            $( ".main-navbar__catalog-menu" ).removeClass( 'show');
        } 
        else {
          $( ".main-navbar__catalog-menu" ).addClass( 'show');
        }
    });
  });