function solve() {
   const info = document.getElementsByClassName('info')[0];
   const departBtn = document.getElementById('depart');
   const arriveBtn = document.getElementById('arrive');
   let stop = '';
   let next = 'depot';
   let apiUrl = `http://localhost:3030/jsonstore/bus/schedule/${next}`;

   async function depart(){
    let res = await fetch(apiUrl);
    let data = await res.json();
    info.textContent = data.name;
    departBtn.disabled = true;
    arriveBtn.disabled = false;
    stop = data.name;
    next = data.next;
   }

   function arrive(){
    info.textContent = stop;
    departBtn.disabled = false;
    arriveBtn.disabled = true;
   }
    return {
        depart,
        arrive
    };
}

let result = solve();