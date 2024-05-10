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
    const [breeding, setBreeding] = useState([])

    useEffect(() =>{
        loadPokemonDetailed(name)
            .then(data => {
                setPokemon(data)
                setMoves(data.moves)
                setAbilities(data.abilities)
                setBreeding(data.breeding)
            })
            .catch(error => console.error('Error fetching initial data:', error));
    }, [])
    
    
    return (
        <div className="infoblocks-wrapper">
            <PokemonInfo pokemon={pokemon}/>
            <BreedingInfo breeding={breeding}/>
            <MovesInfo moves={moves}/>
            <AbilitiesInfo abilities={abilities}/>
        </div>
    )
};

export default InfoBlocks