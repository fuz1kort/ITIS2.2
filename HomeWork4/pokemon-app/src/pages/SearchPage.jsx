import loading from "../assets/loading.gif"
import SearchHeader from "../components/SearchPokemonPage/SearchHeader";
import React, {useEffect, useState} from "react";
import PokemonsList from "../components/SearchPokemonPage/PokemonsList";
import NotFound from "../components/SearchPokemonPage/NotFound";
import loadPokemonsByFilter from "../utils/loadPokemonsByFilter";

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
        if (e.target.documentElement.scrollHeight - (e.target.documentElement.scrollTop + window.innerHeight) < 600 && !fetching) {
            setFetching(true)
        }
    }
    
    useEffect(() => {
            if (fetching) {
                loadPokemonsByFilter(20, offset, searchText)
                    .then(data => {
                        data.map(pokemon => {
                            if (searchText && pokemon.name.includes(searchText.toLowerCase())) {
                                setSearchResults(prevAllPokemons => ({
                                    ...prevAllPokemons,
                                    [pokemon.id]: pokemon
                                }))
                            } else {
                                setAllPokemons(prevAllPokemons => ({
                                    ...prevAllPokemons,
                                    [pokemon.id]: pokemon
                                }));
                            }
                        });
                        setOffset(prevOffset => prevOffset + 10)
                        checkIfFetchingNeeded()
                    })
                    .catch(error => console.error('Error fetching initial data:', error));
            }
        }, [fetching, offset]
    )
    
    const checkIfFetchingNeeded = () => {
        if (searchResults.length === 0) {
            const visiblePokemons = Object.values(allPokemons).filter(pokemon =>
                pokemon.name.includes(searchText.toLowerCase())
            );

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
    }, [searchResults]);

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