import React from 'react';
import PokemonTypes from "../PokemonTypes/PokemonTypes";

const PokemonCard = ({pokemon}) => {
    if (!pokemon) {
        return <div></div>
    }

    return (
        <div className="pokemon-card">
            <div className="card-header">
                <div className="pokemon-name">
                    {pokemon.name[0].toUpperCase() + pokemon?.name.slice(1)}
                </div>
                <div className="pokemon-id">
                    #{pokemon.id.toString().padStart(3, '0')}
                </div>
            </div>
            <div className="card-content">
                <img alt={pokemon.name} className="card-image" src={pokemon.sprites.other.home.front_default}/>
            </div>
            <div className="card-footer">
                <PokemonTypes types={pokemon.types}/>
            </div>
        </div>
    );
};

export default PokemonCard;