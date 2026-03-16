import { marked } from 'marked';

function Description({ markdown }) {
    var html = marked.(markdown, {
        breaks: true,
        gfm: true
    });

    return (
        <div
            className="description"
            dangerouslySetInnerHTML={{ _html: html }}
        />
    );
}

export default Description;