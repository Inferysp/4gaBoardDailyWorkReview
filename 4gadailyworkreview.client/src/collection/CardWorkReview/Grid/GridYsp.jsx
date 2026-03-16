import ButtonYsp from '../../../Button/ButtonYsp.jsx';
import LabelYsp from './Label/LabelYsp.jsx';
import Description from '../../../ParserCardDescription/Description.jsx';
function GridYsp({ name, desc, creator }) {

    return (
        <div className="grid grid-flow-col grid-rows-3 gap-1 box-border p-2 flex object-contain">
            <div className="w-100 row-span-1 ...">
                <LabelYsp text={creator} />
            </div>
            <div className="box-border w-100 col-span-1 row-span-2 ...">
                <LabelYsp text={name} />
            </div>
            <div className="box-content items-center col-start-2 col-end-3 row-span-3 ...">
                <Description markdown={desc || 'Brak opisu'} />
            </div>
            <div className="col-end-4 row-start-3 ...">
                <ButtonYsp name="Edit" />
            </div>
        </div>
    )
}

export default GridYsp;