import GridYsp from "../Grid/GridYsp";

function CardWorkReview({ name, desc, creator }){

    return (
        <div>
            <div className="gap-6 bg-white border-gray-950 border-2">
                <GridYsp name={name} desc={desc} creator={creator} />
            </div>
        </div>
    )
}

export default CardWorkReview;