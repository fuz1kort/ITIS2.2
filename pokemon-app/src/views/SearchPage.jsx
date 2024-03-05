import SearchHeader from "../components/SearchHeader";
import PokemonsList from "../components/PokemonsList";
import React, {useEffect, useState} from "react";
import {all} from "axios";

const SearchPage = () => {
    const [allPokemons, setAllPokemons] = useState([])
    useEffect(() => {
        if (allPokemons.length === 0) {
            fetch('https://pokeapi.co/api/v2/pokemon?limit=151')
                .then(response => response.json())
                .then(data => setAllPokemons(data.results))
                .catch(error => console.error('Error fetching data:', error));
        }
    }, [allPokemons]);
    
    return <div>
        {/*<SearchHeader inputText={inputText} handleChange={handleChange} handleSubmit={handleSubmit}/>*/}
        <SearchHeader/>

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


