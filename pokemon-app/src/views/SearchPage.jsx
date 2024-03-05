import SearchHeader from "../components/SearchHeader";
import PokemonsList from "../components/PokemonsList";
import React, { useEffect, useState } from "react";

const SearchPage = () => {
    const [allPokemons, setAllPokemons] = useState([]);
    const [searchText, setSearchText] = useState('');
    const [searchResults, setSearchResults] = useState([]);

    useEffect(() => {
        if (!allPokemons.length) {
            fetch('https://pokeapi.co/api/v2/pokemon?limit=100')
                .then(response => response.json())
                .then(data => {
                    data.results.forEach(pokemon => fetchPokemonData(pokemon));
                })
                .catch(error => console.error('Error fetching initial data:', error));
        }
    }, [allPokemons]);

    const fetchPokemonData = (pokemon) => {
        fetch(pokemon.url)
            .then(response => response.json())
            .then(pokemonData => {
                setAllPokemons(prevAllPokemons => ({
                    ...prevAllPokemons,
                    [pokemonData.id]: pokemonData
                }));
            })
            .catch(error => console.error('Error fetching data for', pokemon.name, ':', error));
    };

    const handleChange = event => {
        setSearchText(event.target.value);
    };

    const handleSubmit = () => {
        const results = Object.values(allPokemons).filter(pokemon =>
            pokemon.name.includes(searchText.toLowerCase())
        );
        setSearchResults(results);
    };

    return (
        <div>
            <SearchHeader inputText={searchText} handleChange={handleChange} handleSubmit={handleSubmit} />
            {allPokemons.length === 0 ? (
                <div className='loading'>
                    <img alt='loading' src="/loading.gif" />
                </div>
            ) : (
                <PokemonsList pokemons={searchResults.length ? searchResults : Object.values(allPokemons)} />
            )}
        </div>
    );
};

export default SearchPage;