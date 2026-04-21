import react from 'react';
import Description from '../ParserCardDescription/Description.jsx'
export default function BoxCenter({cardName, description}) {

    return (
        <div className="boxCenter">
            <div className="boxCenterTitle">
                <p>{cardName}</p>
            </div>
            <div className="descriptionBoxCenter">
                <Description markdown={description || 'Brak opisu'} />
            </div>
        </div>
    )
}
