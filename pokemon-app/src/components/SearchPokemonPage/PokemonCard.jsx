import React from 'react';
import {Link} from "react-router-dom";
import PokemonTypes from "../PokemonTypes/PokemonTypes";

const PokemonCard = ({pokemon}) => {
    if (!pokemon) {
        return <div></div>
    }

    return (
        <Link to={`/pokemon/${pokemon.name}`}>
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
        </Link>
    );
};

export default PokemonCard;