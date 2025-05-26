const servicos = new Swiper('.telas-swiper', {
    direction: 'horizontal',
    loop: true,
    effect: 'coverflow',
    grabCursor:true,
    centeredSlides:true,
    speed:800,
    slidesPerView:"auto",
    coverflowEffect:{
        rotate:30,
        stretch:80,
        depth:800,
        modifier:1.5,
        slideShadows:false,
    },

    pagination: {
        el: '.swiper-pagination',
        clickable: true,
    },
  });