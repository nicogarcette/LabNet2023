const form = document.getElementById("form");
const InputPlayer = document.getElementById("InputPlayer");
const btnTry = document.getElementById("btnTry");
const Score = document.getElementById("Score");
const HighScore = document.getElementById("HighScore");
const alert = document.getElementById("alert").classList;
const img = document.getElementById("img");
const winner = document.getElementById("winner");
const track = document.getElementById("track");
const refresh = document.getElementById('refresh');

const NumRandom = () => Math.floor(Math.random() * 19) + 1 ;
const numRandom =  NumRandom();
let numPlayer = 0;
let scoreMax = 20;
let valid = false;

const addStorage = (clave,valor) =>{
    localStorage.setItem(clave,valor);
}
const getStorage=()=>{
    
    if (localStorage.getItem("HighScore") !== null) {
        
        let score = JSON.parse(localStorage.getItem("HighScore"));
        HighScore.innerHTML = `HighScore: ${score}`;
    }
}
const validStorage = () => localStorage.getItem("HighScore") < scoreMax && addStorage("HighScore",scoreMax);

function checkInput(value){
    
    if (value === "") {
        alert.remove('hiden'); 
        return false;
    }else{
        value != "" && alert.add('hiden');   
        return true;
    }
}
const numTrack = (a,b) => a > b? a-b : b-a;
const trackMsj =(a,b)=>{
    let num = numTrack(a,b);
   
    if (num >= 15) {
        track.innerHTML = "Demaciado helada la cosa &#129398"
    }else if(num >= 10){
        track.innerHTML = "frioo frioo &#129482"
    }else if(num >= 5){
        track.innerHTML = "se va entibiando  &#128293 &#128293"
    } else if(num > 0 )
        track.innerHTML = "Caliente &#129397 "
}
const discount = ()=>{
    scoreMax--;
    Score.innerHTML = `Score: ${scoreMax}`;
    img.src = "./img/noguta.png";
    trackMsj(numPlayer,numRandom);
    scoreMax == 0 && gameOver();
}
const winTheGame=()=>{
    track.innerHTML = "FELICIDADES CAMPEON!!&#127882"
    HighScore.innerHTML = `HighScore: ${scoreMax}`;
    img.src = "./img/gusta.png";
    winner.classList.remove('hiden');
    InputPlayer.disabled = true;
    validStorage();
}

const gameOver =()=>{
    track.innerHTML = "Perdiste amigazo!&#128531"
    InputPlayer.disabled = true;
}

getStorage();

form.addEventListener('submit', e =>{
    e.preventDefault();
    
    valid = checkInput(InputPlayer.value);

    numPlayer = parseInt(InputPlayer.value);
  
    if (scoreMax > 0 && valid) {
        if (numRandom === numPlayer) {
            winTheGame()  
        }else{
            discount();
        }
    }
});

InputPlayer.addEventListener('focus', ()=>{
    img.src = "./img/pensando.jpg";
})

refresh.addEventListener('click', () => {
    location.reload();
    console.log("restard");
});








