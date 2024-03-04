import SearchHeader from "../components/searchHeader";

const SearchPage = () => {

    fetch('https://pokeapi.co/api/v2/pokemon?limit=151')
        .then(response => response.json())
        .then(function (allpokemon) {
            allpokemon.results.forEach(function (pokemon) {
                fetchPokemonData(pokemon);
            })
        })

    function fetchPokemonData(pokemon) {
        let url = pokemon.url // <--- this is saving the pokemon url to a variable to use in the fetch. 
        //Example: https://pokeapi.co/api/v2/pokemon/1/"
        fetch(url)
            .then(response => response.json())
            .then(function (pokeData) {
                renderPokemon(pokeData)
            })
    }


    function renderPokemon(pokeData){
        let allPokemonContainer = document.getElementById('poke-container');
        let pokeContainer = document.createElement("div") //div will be used to hold the data/details for indiviual pokemon.{}
        pokeContainer.classList.add('ui', 'card');

        let pokeName = document.createElement('h4')
        pokeName.innerText = pokeData.name

        let pokeNumber = document.createElement('p')
        pokeNumber.innerText = `#${pokeData.id}`

        let pokeImage = document.createElement('img')
        pokeImage.srcset = `https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/${pokeData.id}.png`
        pokeImage.className = "poke-image"
        // pokeImage.srcset = `https://projectpokemon.org/images/sprites-models/pgo-sprites/pm${pokeID}.icon.png`

        let pokeImgContainer = document.createElement('div')
        pokeImgContainer.classList.add('image')

        pokeImgContainer.append(pokeImage);

        let pokeTypes = document.createElement('ul')
        
        createTypes(pokeData.types, pokeTypes)

        pokeContainer.append(pokeName, pokeNumber, pokeImgContainer, pokeTypes);
        pokeContainer.classList.add('pokemon-card')
        allPokemonContainer.appendChild(pokeContainer);
    }

    function createTypes(types, ul){
        types.forEach(function(type){
            let typeLi = document.createElement('li');
            typeLi.innerText = type['type']['name'];
            ul.append(typeLi)
        })
    }
    
    return <>
        <SearchHeader/>
        <div id="poke-container">
            
        </div>
    </>
}

export default SearchPage;