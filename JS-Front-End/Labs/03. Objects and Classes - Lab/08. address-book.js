function addressBook(input){
    let addressBookMap = {};
    for(const line of input){
        let [ name, address ] = line.split(':');
        addressBookMap[name] = address;
    }
    let sortedNames = Object.keys(addressBookMap)
        .sort((nameOne, nameTwo) => nameOne.localeCompare(nameTwo));
    for(const name of sortedNames){
        console.log(`${name} -> ${addressBookMap[name]}`)
    }
}