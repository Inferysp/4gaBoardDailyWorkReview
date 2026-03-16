import ButtonYsp from './Button/ButtonYsp.jsx';
import LabelYsp from './Label/LabelYsp.jsx';
import Description from '../../../ParserCardDescription/Description.jsx';
function GridYsp({ name, desc, creator }) {
    const style = "h-full box-border p-2 text-justify max-w-200 text-white bg-gray-500 border-1 border-solid border-pink";
    const scheme = "";

    return (
        <div className="grid grid-flow-col grid-rows-3 gap-1 box-border p-2 flex object-contain ">
            <div className="w-100 row-span-1 ...">
                <div className={`{${scheme}`}>
                    <LabelYsp style={style} text={creator} />
                </div>
            </div>
            <div className="box-border w-100 col-span-1 row-span-2 ...">
                <div className={`{${scheme}`}>
                    <LabelYsp style={style} text={name} />
                </div>
            </div>
            <div className="box-content items-center col-start-2 col-end-3 row-span-3 ...">
                <div className={`{${scheme}`}>
                    <Description style={style} style={`$style`} markdown={desc || 'Brak opisu'} />
                </div>
            </div>
            <div className="col-end-4 row-start-3 ...">
                <div className={`{${scheme}`}>
                    <ButtonYsp style={style} name="Edit" />
                </div>
            </div>
        </div>
    )
}

export default GridYsp;