import SearchHeader from "../components/SearchHeader";
import React, {useEffect, useState} from "react";
import PokemonsList from "../components/PokemonsList";

const SearchPage = () => {
    const [allPokemons, setAllPokemons] = useState([]);
    const [searchText, setSearchText] = useState('');
    const [offset, setOffset] = useState(0);
    const [fetching, setFetching] = useState(true)

    useEffect(() => {
        document.addEventListener('scroll', scrollHandler)

        return function () {
            document.removeEventListener('scroll', scrollHandler)
        }
    })

    const scrollHandler = (e) => {
        if (e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 300 && !fetching) {
            setFetching(true)
        }
    }

    useEffect(() => {
        if (fetching) {
            fetch(`https://pokeapi.co/api/v2/pokemon?limit=60&offset=${offset}`)
                .then(response => response.json())
                .then(data => {
                    data.results.forEach(pokemon => fetchPokemonData(pokemon));
                    setOffset(prevOffset => prevOffset + 30);
                })
                .catch(error => console.error('Error fetching initial data:', error))
                .finally(() => setFetching(false));
        }
    }, [fetching, offset]);

    const fetchPokemonData = (pokemon) => {
        fetch(pokemon.url)
            .then(response => response.json())
            .then(pokemonData => {
                    setAllPokemons(prevAllPokemons => ({
                        ...prevAllPokemons,
                        [pokemonData.id]: pokemonData
                    }));
                }
            )
            .catch(error => console.error('Error fetching data for', pokemon.name, ':', error))
    };

    const handleChange = event => {
        setSearchText(event.target.value);
    };

    return (
        <div>
            <SearchHeader inputText={searchText} handleChange={handleChange}/>
            {allPokemons.length === 0 ? (
                <div className='loading'>
                    <img alt='loading' src="/loading.gif"/>
                </div>
            ) : (
                <PokemonsList pokemons={Object.values(allPokemons).filter(pokemon =>
                    pokemon.name.includes(searchText.toLowerCase()))}/>
            )}
        </div>
    );
}

export default SearchPage;