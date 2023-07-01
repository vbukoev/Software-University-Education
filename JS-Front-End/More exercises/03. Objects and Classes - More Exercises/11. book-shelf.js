function bookShelf(list){
    let res = {}

    function joinNames(name) {
        return name.join(' ')
    }

    list.forEach(item => {
        if(item.includes(' -> ')) {
            let [shelfId, ...shelfGenre] = item.split(' -> ')
            if(!res.hasOwnProperty(shelfId)){
                res[shelfId] = {}
                res[shelfId].genre = joinNames(shelfGenre)
                res[shelfId].books = []
            }
        } else{
            let [bookTitle, data] = item.split(': ')
            let [bookAuthor, bookGenre] = data.split(', ')
            for (const shelf in res) {
                if (res[shelf].genre === bookGenre){
                    res[shelf].books.push({name: bookTitle, author: bookAuthor})
                } 
            }
        }
    })

    const sortedShelves = Object.entries(res).sort((a, b) => {
        const aCount = a[1].books.length
        const bCount = b[1].books.length
        return bCount - aCount;
    });

    sortedShelves.forEach(s => {
        const sNum = s[0]
        const genre = s[1].genre
        const books = s[1].books
        console.log(`${sNum} ${genre}: ${books.length}`)

        books.sort((a, b) => a.name.localeCompare(b.name)).forEach(b=>{
            console.log(`--> ${b.name}: ${b.author}`)
        })
    })
}