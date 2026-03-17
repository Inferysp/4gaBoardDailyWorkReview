import react from 'react';
import Description from '../ParserCardDescription/Description.jsx'
export default function BoxCenter({cardName, description}) {
    var style = "text-lg";

    return (
        <div className="boxcenter">
            <div className={`${style}`}>
                <p>{cardName}</p>
            </div>
            <div>
                <Description markdown={description || 'Brak opisu'} />
            </div>
        </div>
    )
}
