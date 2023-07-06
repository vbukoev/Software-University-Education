function generateReport() {
    const selectedColumns = Array.from(document.querySelectorAll('thead > tr > th > input'));
    const tableContent = Array.from(document.querySelectorAll('tbody > tr'));
    const out = document.querySelector('#output');
    let fields = {};
    let res = [...Array(tableContent.length)].map(() => ({}));
    out.value = '';

    function add(){
        for(let key in fields){
            tableContent.forEach((y, i) =>{
                let text = y.querySelectorAll('td')[fields[key]].textContent;
                Object.assign(res[i], {[key]: text});
            });
        }
    }

    selectedColumns.forEach((e, i) => {
        let [cName, selected] = [e.name, e.checked];
        if(selected){
            fields[cName] = i;
        }
    });

    add();
    out.value = JSON.stringify(res);
}