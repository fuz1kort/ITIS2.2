import React from 'react';
import typeToColor from "../../utils/typesToColors";

const PokemonTypes = ({types}) => {
    return (
        <div className="pokemon-types">
            {types.map(type => <div className="pokemon-type" style={{backgroundColor: typeToColor(type.typeName)}} key={type.typeName}> {type.typeName[0].toUpperCase() + type.typeName.slice(1)}</div>)}
        </div>
    );
};

export default PokemonTypes;