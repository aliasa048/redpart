let choose=document.querySelectorAll('.choose-li')
let chooseMain=document.querySelectorAll('.down-choose')
console.log(choose,chooseMain)
choose[0].onclick=function(){
    chooseMain[0].classList.remove('active')
    chooseMain[1].classList.remove('active')
    chooseMain[2].classList.remove('active')
    choose[0].classList.add('active')
    choose[1].classList.remove('active')
    choose[2].classList.remove('active')
}

choose[1].onclick=function(){
    chooseMain[0].classList.add('active')
    chooseMain[1].classList.add('active')
    chooseMain[2].classList.remove('active')
    choose[0].classList.remove('active')
    choose[1].classList.add('active')
    choose[2].classList.remove('active')
}

choose[2].onclick=function(){
    chooseMain[0].classList.add('active')
    chooseMain[2].classList.add('active')
    chooseMain[1].classList.remove('active')
    choose[0].classList.remove('active')
    choose[1].classList.remove('active')
    choose[2].classList.add('active')
}



let labelProduct=document.querySelectorAll('.product-label')

for(let i=0;i<labelProduct.length;i++){
    labelProduct[i].onclick=()=>{
        removeActive()
        labelProduct[i].classList.add('active')
    }
}

const removeActive = () => {
   
    for(let i=0;i<labelProduct.length;i++){
        labelProduct[i].classList.remove('active')
    }
 }
 


 let colorProduct=document.querySelectorAll('.color-box')

for(let i=0;i<colorProduct.length;i++){
    colorProduct[i].onclick=()=>{
        removecolorActive()
        colorProduct[i].classList.add('active')
    }
}

const removecolorActive = () => {
   
    for(let i=0;i<colorProduct.length;i++){
        colorProduct[i].classList.remove('active')
    }
 }
 

 
let minus=document.querySelector('.minus')
 let plus=document.querySelector('.plus')
 let count=document.querySelector('.count')

 minus.onclick=function(){
   
    if(count.innerText>1){
     count.innerText=Number(count.innerText) -1;
   }
 }
 plus.onclick=function(){
    count.innerText=Number(count.innerText) +1;
 }