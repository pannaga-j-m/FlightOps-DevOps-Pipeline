async function getFlights(){

    const response = await fetch("http://ab1e9a56a81f941fbb5bad9eb87aad60-273528327.ap-south-1.elb.amazonaws.com:3000/api/flights")

    const data = await response.json();

    document.getElementById("result").textContent =
    JSON.stringify(data,null,2);

}
