function solve (a){
    if (!a.method || !isValidMethod(a.method))
        throwError('Method');
    if (!a.uri || !isValidUri(a.uri))
        throwError('URI');
    if (!a.version || !isValidVersion(a.version))
        throwError('Version');
    if (a.message ===undefined || !isValidMessage(a.message))
        throwError('Message')

        function isValidMethod(x){
           return (x === 'GET' || x === 'POST' || x==='DELETE' || x ==='CONNECT')
            ? true : false;
        }
        function throwError(x){
            throw new Error(`Invalid request header: Invalid ${x}`)
        }
        function isValidUri(x){
            return (/^[A-za-z\d.]+$/.test(x) || x==='*') 
            ? true : false;
        }
        function isValidVersion(x){
            return (x==='HTTP/0.9' || x=== 'HTTP/1.0' || x=== 'HTTP/1.1'||  x=== 'HTTP/2.0')
            ? true
            : false;
        }
        function isValidMessage(x){
            if (/[<>\\&'"]/.test(x)) return false;
            return true;
        }
        return a;
}

let obj = {
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: 'asl\\pls'
};
solve(obj);