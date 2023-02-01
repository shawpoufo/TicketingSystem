
    function CreateTicket(ticket){
        fetch("http://localhost:5005/ticket",{
            method:"POST",
            headers: {
                'Accept': 'application/json',
                "Content-Type":"application/json"
            },
            body:JSON.stringify(ticket),
            credentials: 'include'
        })
        .then(response =>{
            if(!response.ok)
                throw new Error("Something wrong")
            return response.json()
        })
        .then(data =>{
            cnnTicket.invoke("JoinTicketHub",data.id)
            tickets.unshift(data)
        })
        .catch(error => console.log(error))
    }

    function closeTicket(){
        fetch(`http://localhost:5005/ticket/close/${selectedDataRow.id}`,{
            method:"POST",
            headers: {
                'Accept': 'application/json',
                "Content-Type":"application/json"
            },
            credentials: 'include'
        })
        .then(response =>{
            if(!response.ok)
                throw new Error("Something wrong")
            const index = tickets.findIndex(t => t.id == selectedDataRow.id)
            tickets[index].status = "Closed"
            
        })
        .catch(error => console.log(error))
    }

    function loadData() {
        const d = fetch("http://localhost:5005/ticket/user", {
            headers: {
                'Accept': 'application/json'
            },
            credentials: 'include'
        })
        .then(response => response.json())
        .then(data => {
            tickets = data
            table.setData(tickets)
        })

    }
