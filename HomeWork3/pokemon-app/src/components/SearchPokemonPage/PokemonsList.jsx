import PokemonCard from "./PokemonCard";
import NotFound from "./NotFound";

const PokemonsList = ({pokemons}) => {
    if (pokemons.length !== 0) {
        return (
            <div className="pokemon-list">
                <div className="pokemon-list-wrapper">
                    {pokemons.map(pokemon => (<PokemonCard pokemon={pokemon} key={pokemon.id}/>))}
                </div>
            </div>
        );
    }
    return (
        <NotFound/>
    )
};

export default PokemonsList;