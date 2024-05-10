import {useEffect, useState} from "react";
import './InfoBlocks.css'
import PokemonInfo from "./Blocks/PokemonInfo";
import BreedingInfo from "./Blocks/BreedingInfo";
import MovesInfo from "./Blocks/MovesInfo";
import AbilitiesInfo from "./Blocks/AbilitiesInfo";
import loadPokemonDetailed from "../../utils/loadPokemonDetailed";

const InfoBlocks = ({name}) => {
    const [pokemon, setPokemon] = useState('')
    const [moves, setMoves] = useState([])
    const [abilities, setAbilities] = useState([])

    useEffect(() =>{
        loadPokemonDetailed(name)
            .then(data => {
                setPokemon(data)
                setMoves(data.moves.map(i => i.move))
                setAbilities(data.abilities.map(i => i.ability))
            })
            .catch(error => console.error('Error fetching initial data:', error));
    }, [])
    
    
    return (
        <div className="infoblocks-wrapper">
            <PokemonInfo pokemon={pokemon}/>
            <BreedingInfo height={pokemon.height} weight={pokemon.weight}/>
            <MovesInfo moves={moves}/>
            <AbilitiesInfo abilities={abilities}/>
        </div>
    )
};

export default InfoBlocks