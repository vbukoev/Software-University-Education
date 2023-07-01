function commentsFunction(list){
    function joinName(name){
        return name.join(' ')
    }

    const res = {
        users: [],
        articles: [],
        comments: {}
    }

    list.forEach(item => {
        let [cmd, ...data] = item.split(' ')
        data = joinName(data)
        if(cmd === 'article' && !res.articles.includes(data)){
            res.articles.push(data)
        } else if(cmd === 'user' && !res.articles.includes(data)){
            res.users.push(data)
        } else{
            let [userData, articleData] = item.split(': ')
            let [userName, ...articleName] = userData.split(' posts on ')
            let [articleTitle, ...articleComment] = articleData.split(', ')

            articleName = joinName(articleName)
            articleComment = joinName(articleComment)

            if(res.users.includes(userName) && res.articles.includes(articleName)){
                if(!res.comments.hasOwnProperty(articleName)){
                    res.comments[articleName] = {}
                    res.comments[articleName].userWithComments = []
                }

                res.comments[articleName].userWithComments.push({
                    userName: userName,
                    title: articleTitle,
                    comment: articleComment
                })
            }
        }
    })

    const sortedArticles = res.articles.sort((a, b) => {
        const aComments = res.comments[a].userWithComments.length;
        const bComments = res.comments[b].userWithComments.length;
        return bComments - aComments
    })

    sortedArticles.forEach(article => {
        const comms = res.comments[article].userWithComments;
        if(comms.length){
            console.log(`Comments on ${article}`)
            comms.sort((a, b) => a.userName.localeCompare(b.userName)).forEach(c => {
                console.log(`--- From user ${c.userName}: ${c.title} - ${c.comment}`)
            })
        }
    })
}

//commentsFunction(
//    ['user aUser123', 'someUser posts on someArticle: NoTitle, stupidComment', 'article Books', 'article Movies', 'article Shopping', 'user someUser', 'user uSeR4', 'user lastUser', 'uSeR4 posts on Books: I like books, I do really like them', 'uSeR4 posts on Movies: I also like movies, I really do', 'someUser posts on Shopping: title, I go shopping every day', 'someUser posts on Movies: Like, I also like movies very much']
//)