import React from 'react';
import {
  StyleSheet,
  Text,
  Image,
  View,
  FlatList,
} from 'react-native';

import DetailsShowButton from './../../components/DetailsShowButton';



export default function Details(props){

  const data = props.route.params.data

  return(
    <FlatList style={styles.container}
      ListHeaderComponent={ () =>{
        return(
          <View>
            <Image style={styles.itemimage} source={data.imageLink}/>

            <View style={{backgroundColor:'white',}}>
              <Text style={styles.title}>Informações Básicas</Text>            
            </View>

            <View style={{ flexDirection:'column', alignItems: 'center',}}>
                {data.informacoesBasicas.ordemOrbital!= null && <DetailsShowButton name="Ordem Orbital" value={data.informacoesBasicas.ordemOrbital}/>}
                {data.informacoesBasicas.distanciaDoSol !=null && <DetailsShowButton name="Distância Do Sol" value={data.informacoesBasicas.distanciaDoSol}/>}

                <DetailsShowButton name="Massa" value={data.informacoesBasicas.massa}/>
                {data.informacoesBasicas.volume !=null && <DetailsShowButton name="Volume" value={data.informacoesBasicas.volume}/>}
                {data.informacoesBasicas.densidade !=null && <DetailsShowButton name="Densidade" value={data.informacoesBasicas.densidade}/>}
                {data.informacoesBasicas.areaDaSuperficie !=null && <DetailsShowButton name="Área da Superfície" value={data.informacoesBasicas.areaDaSuperficie}/>}
                {data.informacoesBasicas.temperatura !=null && <DetailsShowButton name="Temperatura" value={data.informacoesBasicas.temperatura}/>}

 
                {data.informacoesBasicas.periodoDeRotacao !=null && <DetailsShowButton name="Período de Rotação" value={data.informacoesBasicas.periodoDeRotacao}/>}
                {data.informacoesBasicas.periodoDeRevolucao!=null && <DetailsShowButton name="Período De Revolução" value={data.informacoesBasicas.periodoDeRevolucao}/>}
                {data.informacoesBasicas.gravidade!=null && <DetailsShowButton name="Gravidade" value={data.informacoesBasicas.gravidade}/>}
                {data.informacoesBasicas.velocidadeDeEscape!=null && <DetailsShowButton name="Velocidade De Escape" value={data.informacoesBasicas.velocidadeDeEscape}/>}
                {data.informacoesBasicas.satelites!=null &&<DetailsShowButton name="Satélites" value={data.informacoesBasicas.satelites}/>}

                {data.informacoesBasicas.estrela!=null &&<DetailsShowButton name="Estrela" value={data.informacoesBasicas.estrela}/>}
                {data.informacoesBasicas.planetas!=null &&<DetailsShowButton name="Planetas" value={data.informacoesBasicas.planetas}/>}
                {data.informacoesBasicas.planetasAnoes!=null &&<DetailsShowButton name="Planetas Anões" value={data.informacoesBasicas.planetasAnoes}/>}
                {data.informacoesBasicas.planetasInferiores!=null &&<DetailsShowButton name="Planetas Inferiores" value={data.informacoesBasicas.planetasInferiores}/>}
                {data.informacoesBasicas.planetasSuperiores!=null &&<DetailsShowButton name="Planetas Superiores" value={data.informacoesBasicas.planetasSuperiores}/>}
                {data.informacoesBasicas.planetasJovianos!=null &&<DetailsShowButton name="Planetas Jovianos" value={data.informacoesBasicas.planetasJovianos}/>}
                {data.informacoesBasicas.planetasTeluricos!=null &&<DetailsShowButton name="Planetas Telúricos" value={data.informacoesBasicas.planetasTeluricos}/>}

            </View>

              <View style={{backgroundColor:'white',}}>
                <Text style={styles.title}>Curiosidades</Text>            
              </View>

          </View>
        )
      }}
      data={data.curiosidades}
      keyExtractor={ item => item.id}
      showsVerticalScrollIndicator={false}
      renderItem = {({item,index}) =>(
        <View style={styles.curioHolder}>
          <Text style={styles.curioTitle}>{index+1}. {item.titulo}</Text>
          <Text style={styles.curioHistory}>{item.historia}</Text>
        </View>
      )}
    
    />
  )
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor:'red',
      flexDirection: 'column',
      backgroundColor: 'black',
    },
    itemimage: {
      width:'100%',
      height: 200,
      flexGrow: 1,
      opacity: 0.9,
      borderRadius: 40,
      borderTopLeftRadius: 0,
      borderTopRightRadius: 0,
    },
    title: {
      color:'black', 
      fontSize:25,
      textAlign:'center',
    },
    curioHolder:{
      //marginHorizontal: 5,
      //marginVertical: 10,
    },
    curioTitle:{
      color: 'white',
      marginTop: 10,
      marginBottom: 5,
      textAlign: 'center',
      fontWeight: 'bold',
      fontSize: 25,
    },
    curioHistory:{
      color: 'white',
      textAlign: 'justify',
      marginHorizontal: 20,
    }

  });
