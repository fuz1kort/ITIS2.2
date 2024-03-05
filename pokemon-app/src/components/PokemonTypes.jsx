import React from 'react';
import typeToColor from "./typesToColors";

const PokemonTypes = ({types}) => {
    
    return (
        <div className="pokemon-types">
            {types.map(type => <div className="pokemon-type" style={{backgroundColor: typeToColor(type.type.name)}} key={type.type.name}> {type?.type.name[0].toUpperCase() + type.type?.name.slice(1)}</div>)}
        </div>
    );
};

export default PokemonTypes;