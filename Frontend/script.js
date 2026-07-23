async function getFlights(){

    const response = await fetch(
        "http://flight-backend-service:3000/api/flights"
    );

    const data = await response.json();

    document.getElementById("result").textContent =
    JSON.stringify(data,null,2);

}
