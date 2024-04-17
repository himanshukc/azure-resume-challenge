window.addEventListener('DOMContentLoaded' , (event) => {
    getVisitCount (); // Call the getVisitCount function
})


//URL for the local backend API (for testing)
const functionApiURL = 'https://azureresumefunction.azurewebsites.net/api/ResumeChallengeCounter?code=3M0ZFOKPI3x1HigOxnrygUYWgTrLYy_vXyXiXQzhXQ5UAzFuz8zkeA=='
const localfunctionApi = 'http://localhost:7071/api/ResumeChallengeCounter';

//This function fetches the visit count from the backend API and displays it on the webpage
const getVisitCount = () => {
    let count = 30;
    fetch(functionApiURL).then(response => {
        return response.json()
    }).then (response =>{
        console.log ("Website called function API.");
        count = response.count;
        document.getElementById ("counter").innerText = count;
    }).catch (function(error){
        console.log(error);
    });

    return count;
}
    
