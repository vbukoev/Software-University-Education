function phoneBook(input) {
    let phonebook = {};
    for (let line of input) {
    let tokens = line.split(' ');
    let name = tokens[0];
    let number = tokens[1];
    phonebook[name] = number;
    }
    for (let key in phonebook) {
    console.log(`${key} -> ${phonebook[key]}`);
    }
    }

//    phoneBook(['Tim 0834212554', 
//'Peter 0877547887', 
//'Bill 0896543112', 
//'Tim 0876566344']);