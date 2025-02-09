const nav = document.querySelector('.nav');

window.addEventListener('scroll', fixNav);

function fixNav(){
  if(window.scrollY > nav.offsetHeight + 150){
    nav.classList.add('active');
  }else{
    nav.classList.remove('active');
  }
}




// Photo slider
const slides = document.querySelectorAll('.slide');
const prevBtn = document.querySelector('.prev');
const nextBtn = document.querySelector('.next');
let currentSlide = 0;

function showSlide() {
  slides.forEach(slide => slide.style.display = 'none');
  slides[currentSlide].style.display = 'block';
}

function nextSlide() {
  currentSlide = (currentSlide + 1) % slides.length;
  showSlide();
}

function prevSlide() {
  currentSlide = (currentSlide - 1 + slides.length) % slides.length;
  showSlide();
}

// Initial display
showSlide();
prevBtn.addEventListener('click', prevSlide);
nextBtn.addEventListener('click', nextSlide);




