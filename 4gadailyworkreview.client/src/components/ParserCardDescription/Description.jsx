import { marked } from 'marked';

function Description({ markdown }) {
    const html = marked(markdown, {
        breaks: true,
        gfm: true
    });

    return (
        <div className="descriptionBox">
            <div
                dangerouslySetInnerHTML={{ __html: html }}
            />
        </div>
    );
}

export default Description;