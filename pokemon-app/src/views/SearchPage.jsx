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
            fetch(`https://pokeapi.co/api/v2/pokemon?limit=10&offset=${offset}`)
                .then(response => response.json())
                .then(data => {
                    const promises = data.results.map(pokemon => fetchPokemonData(pokemon));
                    Promise.all(promises).then(() => {
                        setOffset(prevOffset => prevOffset + 10);
                        checkIfFetchingNeeded();
                    });
                })
                .catch(error => console.error('Error fetching initial data:', error));
        }
    }, [fetching, offset, searchText]);

    const checkIfFetchingNeeded = () => {
        const visiblePokemons = Object.values(allPokemons).filter(pokemon =>
            pokemon.name.includes(searchText.toLowerCase())
        );
        if (visiblePokemons.length <= 70) {
            setFetching(true);
        } else {
            setFetching(false);
        }
    };

    const fetchPokemonData = async (pokemon) => {
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
        checkIfFetchingNeeded()
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