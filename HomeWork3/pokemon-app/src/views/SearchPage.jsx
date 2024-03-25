import loading from "../../assets/loading.gif"
import SearchHeader from "./components/SearchHeader";
import React, {useEffect, useState} from "react";
import PokemonsList from "./components/PokemonsList";
import NotFound from "./components/NotFound";

const SearchPage = () => {
    const [allPokemons, setAllPokemons] = useState([]);
    const [searchResults, setSearchResults] = useState([]);
    const [searchText, setSearchText] = useState('');
    const [isSearching, setAsSearching] = useState(false);
    const [offset, setOffset] = useState(0);
    const [fetching, setFetching] = useState(true)

    useEffect(() => {
        document.addEventListener('scroll', scrollHandler)

        return function () {
            document.removeEventListener('scroll', scrollHandler)
        }
    })

    const scrollHandler = (e) => {
        if (e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 100 && !fetching) {
            setFetching(true)
        }
    }

    useEffect(() => {
            if (fetching) {
                fetch(`https://pokeapi.co/api/v2/pokemon?limit=40&offset=${offset}`)
                    .then(response => response.json())
                    .then(data => {
                        data.results.map(pokemon => fetchPokemonData(pokemon));
                        setOffset(prevOffset => prevOffset + 20)
                    })
                    .catch(error => console.error('Error fetching initial data:', error));
            }
        }, [fetching]
    )

    const checkIfFetchingNeeded = () => {
        if (searchResults.length === 0) {
            const visiblePokemons = Object.values(allPokemons)

            if (visiblePokemons.length === 0) {
                return
            }
            if (visiblePokemons.length <= 70) {
                setFetching(true);
            } else {
                setFetching(false);
            }
        } else {
            const visiblePokemons = Object.values(searchResults);
            if (visiblePokemons.length <= 70) {
                setFetching(true);
            } else {
                setFetching(false);
            }
        }
    };

    const fetchPokemonData = (pokemon) => {
        fetch(pokemon.url)
            .then(response => response.json())
            .then(pokemonData => {
                    if (searchText && pokemonData.name.includes(searchText.toLowerCase())) {
                        setSearchResults(prevAllPokemons => ({
                            ...prevAllPokemons,
                            [pokemonData.id]: pokemonData
                        }))
                    } else {
                        setAllPokemons(prevAllPokemons => ({
                            ...prevAllPokemons,
                            [pokemonData.id]: pokemonData
                        }));
                    }
                    
                setFetching(false)
                }
            )
            .catch(error => console.error('Error fetching data for', pokemon.name, ':', error))
    };

    const handleChange = event => {
        setSearchText(event.target.value);
    };

    const handleSubmit = () => {
        setAsSearching(true)
        if (searchText) {
            let results = Object.values(allPokemons).filter(pokemon =>
                pokemon.name.includes(searchText.toLowerCase()))
            setSearchResults(results)
        } else {
            setSearchResults([])
            setAllPokemons([])
            setAsSearching(false)
            setFetching(true)
            setOffset(0)
        }
    };

    useEffect(() => {
        checkIfFetchingNeeded();
    }, [searchResults, allPokemons]);

    return (
        <div>
            <SearchHeader inputText={searchText} handleChange={handleChange} handleSubmit={handleSubmit}/>
            <div className="search-page-content">
                {searchResults.length === 0 ? (
                    allPokemons.length === 0 ? (
                        <div className='loading'>
                            <img alt='loading' src={loading}/>
                        </div>
                    ) : (
                        isSearching ? (
                            <NotFound/>
                        ) : (
                            <PokemonsList
                                pokemons={Object.values(allPokemons)}/>
                        )
                    )
                ) : (
                    <PokemonsList pokemons={Object.values(searchResults)}/>
                )}
            </div>
        </div>
    );
}

export default SearchPage;