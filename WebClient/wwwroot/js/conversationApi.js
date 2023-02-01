// const cnnConversation = new signalR.HubConnectionBuilder().withUrl("/hub/conversation").build();
// cnnConversation.start()
// .then(function(){
//     console.log("CONNECTED TO CHAT ")
// })

function loadConversation(ticketId)
{
    fetch(`http://localhost:5005/conversation/${ticketId}`, {
        headers: {
            'Accept': 'application/json'
        },
        credentials: 'include'
    })
    .then(response => response.json())
    .then(data => {
        data.forEach(message => {
            addMessageToChatBox(message)   
        });
        console.log(data)
        
    })
}

function addMessageToChatBox(message){
    const chatBox = document.getElementById("chatBox")
    let cssClass = "overflow-scroll"
    if(message.iOwnIt)
        cssClass = cssClass.concat("text-end bg-body text-white");
    let div = document.createElement("div");
    div.setAttribute("class",cssClass)
    div.innerText = message.text
    chatBox.appendChild(div)
}

function SendMessage(){

    const body = {
        Text:document.getElementById("textMessage").value,
        TicketId:selectedDataRow.id
    }


    fetch(`http://localhost:5005/conversation`,{
        method:"POST",
        headers: {
            'Accept': 'application/json',
            "Content-Type":"application/json"
        },
        credentials: 'include',
        body:JSON.stringify(body)
    })
    .then(response =>{
        if(!response.ok)
            throw new Error(response)
        return response.json()
    })
    .then(data =>{
        cnnTicket.invoke("Send",data)
        .catch(error => console.error(error))
    })
    .catch(error => console.error(error))
}

document.getElementById("btnSend").addEventListener("click",(e)=>{
    SendMessage()
    addMessageToChatBox({text:document.getElementById("textMessage").value,iOwnIt:true})
})

cnnTicket.on("ReceiveMessage",function(message){
    console.log("MESSAGE RECEIVED : "+message)
    if(message.ticketId === selectedDataRow.id)
    {
        addMessageToChatBox(message)
    }
})
