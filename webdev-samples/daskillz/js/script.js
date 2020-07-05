function findIndex(category) {
    let postfix = "-index";
    return document.querySelector("#" + category + postfix);
}

function findArticle(category) {
    let postfix = "-article";
    return document.querySelector("#" + category + postfix);
}

function addToIndex(skill) {
    let linkNode = document.createElement("a");
    linkNode.setAttribute("href", "#" + skill.name);
    linkNode.innerText = skill.name;
    let itemNode = document.createElement("li");
    itemNode.appendChild(linkNode)
    let index = findIndex(skill.category);
    index.appendChild(itemNode);
}

function getLogoOrDefault(techName) {
    let http = new XMLHttpRequest();
    let logoUrl = "img/" + encodeURI(techName.replace("#", "sharp")) + ".png";
    http.open('HEAD', logoUrl, false);
    http.send();
    return http.status != 404 ? logoUrl : "img/check.png";
}

function createTechnologyNode(tech) {
    let techArticleNode = document.createElement("article");
    techArticleNode.setAttribute("class", "tech-article");

    let imgNode = document.createElement("img");
    imgNode.setAttribute("alt", tech.name);
    imgNode.setAttribute("src", getLogoOrDefault(tech.name));

    let spanNode = document.createElement("span");
    spanNode.appendChild(imgNode);
    spanNode.append(tech.name);
    
    let meterNode = document.createElement("div");
    meterNode.setAttribute("class", "meter");
    let percent = 100 * ( (tech.level ?? 5) / 10);
    meterNode.innerHTML = '<span style="width: '+percent+'%"></span>';

    techArticleNode.appendChild(spanNode);
    techArticleNode.appendChild(meterNode);
    return techArticleNode;
}

function addToShowroom(skill) {
    let anchorNode = document.createElement("a");
    anchorNode.setAttribute("name", skill.name);    // since I use names as anchors, those names should be unique
    let headerNode = document.createElement("H3");
    headerNode.innerHTML = skill.description;
    let examplesNode = document.createElement("p");
    skill.skills.forEach(example => {
        examplesNode.innerText += example + "; ";
    })
    let sectionNode = document.createElement("section");
    skill.technologies.forEach(tech => {
        let techArticleNode = createTechnologyNode(tech);
        sectionNode.appendChild(techArticleNode);
    })
    let article = findArticle(skill.category);
    article.appendChild(anchorNode);
    article.appendChild(headerNode);
    article.appendChild(examplesNode);
    article.appendChild(sectionNode);
}

fetch('/data/skillz.json')
    .then(response => response.json())
    .then(jsonResponse => {
        jsonResponse.forEach(skill => {
            addToIndex(skill);
            addToShowroom(skill);
        });
    })
