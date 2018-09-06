class Calculator:
    character = ['/', '*', '+', '-', '(', ')', '^']
    priority = {
        '^': 3,
        '*': 2,
        '/': 2,
        '+': 1,
        '-': 1,
        '(': 0,
        '#' : 4
    }

    def add_to_stack(self, stack, opz, symbol):
        while len(stack) > 0 and self.priority[symbol] <= self.priority[stack[len(stack) - 1]] and not stack[
                                                                                                 len(stack) - 1] == '(':
            opz.append(stack.pop())
        stack.append(symbol)

    def convert_to_opz(self, text):
        text = text.replace(' ', '')
        opz = []
        stack = []
        previous_symbol = ''
        for symbol in text:
            if symbol.isdigit():
                if len(opz) > 0 and (previous_symbol.isdigit() or previous_symbol == '.'):
                    opz[len(opz)-1] += symbol
                else:
                    opz.append(symbol)
            elif symbol == '.':
                if len(opz) > 0 and previous_symbol.isdigit():
                    opz[len(opz)-1] += symbol
                else:
                    raise ValueError('Неправильная запись дробного числа')
            elif symbol not in self.character and not symbol == '.':
                print(symbol)
                raise ValueError('Неправильные символы')
            elif symbol == '(':
                stack.append(symbol)
            elif symbol == ')':
                if len(stack) == 0:
                    raise ValueError('Ошибка в составлении выражения со скобками')
                else:
                    while not stack[len(stack)-1] == '(':
                        opz.append(stack.pop())
                    stack.pop()
            else:
                if symbol == '-' and (previous_symbol == '' or previous_symbol in self.character):
                    opz.append('-1')
                    self.add_to_stack(stack, opz, '#')
                else:
                    self.add_to_stack(stack, opz, symbol)
            previous_symbol = symbol
        opz.extend(stack[::-1])
        print(opz)
        return opz

    def calc(self, text):
        opz = self.convert_to_opz(text)
        result = []
        for symbol in opz:
            print(result)
            if symbol[0] == '-' and len(symbol) > 0:
                result.append(symbol)
            elif symbol.isdigit():
                result.append(symbol)
            elif '.' in symbol:
                result.append(symbol)
            else:
                y = float(result.pop())
                x = float(result.pop())
                if symbol == '^':
                    result.append(pow(x, y))
                elif symbol == '#':
                    result.append(x*y)
                else:
                    try:
                        result.append(eval('{}{}{}'.format(x, symbol, y)))
                    except:
                        raise ValueError("Данное выражение невозможно вычислить")
        if len(result) > 1:
            raise ValueError("Неправильно составлено выражение")
        print(result)
        return result[0]
