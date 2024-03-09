import loading from "../assets/loading.gif"
import SearchHeader from "../components/SearchPokemonPage/SearchHeader";
import React, {useEffect, useState} from "react";
import PokemonsList from "../components/SearchPokemonPage/PokemonsList";

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
        if (e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 600 && !fetching) {
            setFetching(true)
        }
    }

    useEffect(() => {
            if (fetching) {
                fetch(`https://pokeapi.co/api/v2/pokemon?limit=20&offset=${offset}`)
                    .then(response => response.json())
                    .then(data => {
                        data.results.map(pokemon => fetchPokemonData(pokemon));
                        setOffset(prevOffset => prevOffset + 20)
                        checkIfFetchingNeeded()
                    })
                    .catch(error => console.error('Error fetching initial data:', error));
            }
        }, [fetching, offset]
    )
    ;

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

    useEffect(() => {
        checkIfFetchingNeeded();
    }, [searchText]);

    return (
        <div>
            <SearchHeader inputText={searchText} handleChange={handleChange}/>
            <div className="search-page-content">
                {allPokemons.length === 0 ? (
                    <div className='loading'>
                        <img alt='loading' src={loading}/>
                    </div>
                ) : (
                    <PokemonsList pokemons={Object.values(allPokemons).filter(pokemon =>
                        pokemon.name.includes(searchText.toLowerCase()))}/>
                )}
            </div>
        </div>
    );
}

export default SearchPage;