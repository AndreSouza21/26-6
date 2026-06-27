André Ferreira Santos 176013 \n
André Souza de Almeida 176024

## Como executar

1. Abra o arquivo `Atividade-Strategy.sln` ou a pasta do projeto no Visual Studio.
2. Pressione `F5` ou `Ctrl+F5` para compilar e executar.

### Linha de comando

```bash
msbuild Atividade-Strategy.csproj
bin\Debug\Atividade-Strategy.exe
```

### Fluxo do programa
1. Mostra dois exemplos um com entrada valida e outro com entrada invalida.
2. O programa pede o **nome do usuário**.
3. Pergunta se você quer consultar a estratégia do **dia atual** (opção 1) ou de um 
   **dia informado manualmente** (opção 2).
4. Pede uma **informação adicional** (nome de tarefa pendente, meta semanal, etc.),
   que é repassada para a estratégia do dia.
5. Exibe o usuário, o dia consultado, a prioridade (`ALTA`, `MEDIA` ou `BAIXA`) e a
   mensagem da estratégia correspondente.

## Estrutura das estratégias

O programa segue o padrão **Strategy**, evitando qualquer cadeia extensa de
`if/else` ou `switch` para decidir o comportamento de cada dia. 


**Como funciona:**

- `IEstrategiaDia` é a **Estratégia**: uma interface que declara o método
  `Executar(informacaoAdicional)`, comum a todas as estratégias concretas.
- Cada dia da semana tem sua própria **EstrategiaConcreta**
  (`EstrategiaSegunda` ... `EstrategiaDomingo`), implementando `IEstrategiaDia`
  e devolvendo a mensagem e a prioridade descritas no enunciado.
- `EstrategiaPadrao` também implementa `IEstrategiaDia`, mas representa a
  ausência de comportamento: é usada sempre que o dia informado é inválido,
  inexistente ou não possui estratégia cadastrada. Isso evita verificações de
  nulo espalhadas pelo código e garante que o programa nunca seja interrompido
  por falta de estratégia.
- `SeletorEstrategia` é o **Contexto**: ele não sabe *o que* cada dia faz,
  apenas sabe *qual* `IEstrategiaDia` corresponde a cada dia. Ele guarda um
  `Dictionary<string, IEstrategiaDia>` que mapeia o nome do dia (normalizado,
  sem acento e em minúsculas) para o objeto de estratégia correspondente. A
  seleção é uma simples consulta ao dicionário (`TryGetValue`) — não há
  nenhuma sequência de condicionais comparando dia por dia. Se a chave não
  existir, ou se o dia vier vazio/nulo, ele devolve a `EstrategiaPadrao`.
- O Contexto **delega** a execução: ele só escolhe a estratégia; quem de fato
  executa o comportamento é a própria estratégia, ao receber a chamada
  `estrategia.Executar(informacaoAdicional)`.
- `CalendarioSemana` usa `DateTime.Now.DayOfWeek` (recurso nativo do .NET) para
  obter o dia atual e converte o `enum DayOfWeek` para o nome em português
  usado pelo `SeletorEstrategia`.
- `ResultadoEstrategia` é um objeto simples (DTO) que carrega a `Prioridade`
  (`ALTA`, `MEDIA` ou `BAIXA`) e a mensagem final, devolvidos por qualquer
  estratégia executada.



## Questões de reflexão

1. **Como evitar verificações repetidas de valores nulos no código principal?**

   Usando um dicionário que mapeia cada dia para sua estratégia, e fazendo a
   busca retornar sempre um objeto válido, nunca `null`. Dessa forma, o código
   principal simplesmente chama `estrategia.Executar(info)` sem precisar verificar
   `if (estrategia != null)` em nenhum momento. A responsabilidade de lidar com a
   ausência fica encapsulada no componente de seleção, não espalhada pelo cliente.

2. **Como representar a ausência de uma estratégia de forma segura, sem usar
   `null`?**

   O seletor nunca devolve `null`: quando o dia não existe no dicionário (ou
   vem vazio/inválido), ele devolve `EstrategiaPadrao`, uma estratégia
   concreta que implementa `IEstrategiaDia` normalmente, mas com
   comportamento neutro, por exemplo, retornando uma mensagem genérica de
   "dia não reconhecido". Ou seja, a ausência de estratégia é representada
   por **mais uma estratégia concreta**, e não por um valor nulo.

3. **Como essa solução é incorporada ao projeto?**
   - `EstrategiaPadrao` implementa a mesma interface `IEstrategiaDia` das
     demais estratégias (método `Executar(informacaoAdicional)`), mas seu
     comportamento é inócuo, responde de forma segura sem lançar exceção.
   - O seletor (`SeletorEstrategia`) usa
     `dicionario.TryGetValue(dia, out estrategia)`: se o dia não existir no
     mapa, ele já retorna `EstrategiaPadrao` automaticamente.
   - O código principal nunca precisa saber se a estratégia retornada é uma
     das estratégias "normais" (segunda a domingo) ou a padrão: chama
     `Executar(info)` do mesmo jeito em todos os casos.

   Isso mantém o polimorfismo intacto e elimina condicionais defensivas no
   fluxo principal, que é exatamente a ideia central do padrão Strategy: o
   contexto (`SeletorEstrategia`) escolhe a estratégia por consulta, nunca por
   uma cadeia de `if/else`, e qualquer estratégia, incluindo a padrão, é
   tratada de forma uniforme pelo cliente.


