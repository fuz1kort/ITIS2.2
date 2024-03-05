import React, {useEffect, useState} from 'react';
import {Link} from "react-router-dom";
import PokemonTypes from "./PokemonTypes";

const PokemonCard = ({url}) => {
    const [pokeData, setPokeData] = useState(null);

    useEffect(() => {
        fetch(url)
            .then(response => response.json())
            .then(data => {
                setPokeData(data);
            })
            .catch((error) => {
                console.log('There was an ERROR: ', error);
            });
    }, [url]);

    
    if (!pokeData) {
            return <div></div>
    }
    console.log(pokeData.types)
    return (
        <Link to={`details/${pokeData.name}`}>
            <div className="pokemon-card">
                <div className="card-header">
                    <div className="pokemon-name">
                        {pokeData?.name[0].toUpperCase() + pokeData?.name.slice(1)}
                    </div>
                    <div className="pokemon-id">
                        #{pokeData?.id.toString().padStart(3, '0')}
                    </div>
                </div>
                <div className="card-content">
                    <img alt={pokeData.name} className="card-image" src={pokeData.sprites.other.home.front_default}/>
                </div>
                <div className="card-footer">
                        <PokemonTypes types={pokeData.types}/>)
                </div>
            </div>
        </Link>
    );
};

export default PokemonCard;