function shoppingList(input){
    input.pop();
    const products = input.shift().split('!');
    const cmds = input;

    cmds.forEach((line) => {
        const cmd = line.split(' ')[0];   
        const item = line.split(' ')[1];          
        
        switch (cmd) {
            case 'Urgent':
                if(!products.includes(item)){
                    products.splice(0, 0, item);
                }
                break;
            case 'Unnecessary':
                if(products.includes(item)){
                    products.splice(products.indexOf(item), 1);
                }
                break;
            case 'Correct':
                const newItem = line.split(' ')[2];
                if(products.includes(item)){
                    products.splice(products.indexOf(item), 1, newItem);
                }
                break;
            case 'Rearrange':               
               if(products.includes(item)){
                   products.splice(products.indexOf(item), 1);
                   products.push(item);
               }
               break;
            default:
                break;
        }
    });

    console.log(products.join(', '));
}

//shoppingList((["Tomatoes!Potatoes!Bread",
//"Unnecessary Milk",
//"Urgent Tomatoes",
//"Go Shopping!"])
//)

//shoppingList((["Milk!Pepper!Salt!Water!Banana",
//"Urgent Salt",
//"Unnecessary Grapes",
//"Correct Pepper Onion",
//"Rearrange Grapes",
//"Correct Tomatoes Potatoes",
//"Go Shopping!"])
//)