import SearchHeader from "../components/SearchHeader";
import PokemonsList from "../components/PokemonsList";
import React, {useEffect, useState} from "react";
import PokemonCard from "../components/PokemonCard";

const SearchPage = () => {
    const [allPokemons, setAllPokemons] = useState([])
    const [searchText, setSearchText] = useState('')
    const [searchResults, setSearchResults] = useState([]);
    useEffect(() => {
        if (allPokemons.length === 0) {
            fetch('https://pokeapi.co/api/v2/pokemon?limit=1000')
                .then(response => response.json())
                .then(data => setAllPokemons(data.results))
                .catch(error => console.error('Error fetching data:', error));
        }
    }, [allPokemons]);

    let parsedPokemons = allPokemons.((pokemon) => {
        useEffect(() => {
            fetch(pokemon.url)
                .then(response => response.json())
        });
    }, [allPokemons]);

    const handleChange = event => {
        setSearchText(event.target.value)
    }

    const handleSubmit = () => {
        const results = allPokemons.filter(pokemon =>
            pokemon.name.includes(searchText)
        );
        setSearchResults(results);
        setSearchText('')
    }


    return <div>
        <SearchHeader inputText={searchText} handleChange={handleChange} handleSubmit={handleSubmit}/>
        {allPokemons.length === 0 ? (
            <div className='loading'>
                <img alt='loading' src="/loading.gif"/>
            </div>
        ) : (
            <div>
                <PokemonsList pokemons={allPokemons}/>
            </div>
        )}
    </div>
}

export default SearchPage;


